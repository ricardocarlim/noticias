// Infrastructure/Data/Repositories/NoticiaRepository.cs
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class NoticiaTagRepository : IRepository<NoticiaTag>
{
    private readonly AppDbContext _context;

    public NoticiaTagRepository(AppDbContext context)
    {
        _context = context;
    }

    public int Add(NoticiaTag entity)
    {
        _context.NoticiaTags.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Update(NoticiaTag entity)
    {
        _context.NoticiaTags.Update(entity);
        _context.SaveChanges();
    }

    public NoticiaTag GetById(int id)
    {
        return _context.NoticiaTags.Find(id);
    }

    public IEnumerable<NoticiaTag> GetByIdTag(int idTag)
    {
        return _context.NoticiaTags.Where(x => x.TagId == idTag).ToList();
    }

    public IEnumerable<NoticiaTag> GetAll()
    {
        return _context.NoticiaTags.ToList();
    }

    public void Delete(NoticiaTag entity)
    {        
        var noticiasTags = _context.NoticiaTags.Where(x => x.NoticiaId == entity.NoticiaId).ToList();     
        _context.NoticiaTags.RemoveRange(noticiasTags);
        _context.SaveChanges();
    }
}
