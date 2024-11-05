// Infrastructure/Data/Repositories/NoticiaRepository.cs
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class NoticiaRepository : IRepository<Noticia>
{
    private readonly AppDbContext _context;

    public NoticiaRepository(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Noticia entity)
    {
        _context.Noticias.Add(entity);
        _context.SaveChanges();
        return entity.Id; // Retorna o ID gerado
    }

    public void Update(Noticia entity)
    {
        _context.Noticias.Update(entity);
        _context.SaveChanges();
    }
    
    public Noticia GetById(int id)
    {
        return _context.Noticias
                  .Include(n => n.NoticiaTags)
                  .ThenInclude(nt => nt.Tag) 
                  .FirstOrDefault(n => n.Id == id);
    }

    public IEnumerable<Noticia> GetAll()
    {
        return _context.Noticias.ToList();
    }

    public void Delete(Noticia entity)
    {
        var noticia = GetById(entity.Id);
        if (noticia != null)
        {
            _context.Noticias.Remove(noticia);
            _context.SaveChanges();
        }
    }

    public IEnumerable<NoticiaTag> GetByIdTag(int idTag)
    {
        throw new NotImplementedException();
    }
}
