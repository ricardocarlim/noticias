// Infrastructure/Data/Repositories/NoticiaRepository.cs
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class UsuarioRepository : IRepository<Usuario>
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Usuario entity)
    {
        _context.Usuarios.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Update(Usuario entity)
    {
        _context.Usuarios.Update(entity);
        _context.SaveChanges();
    }
    
    public Usuario GetById(int id)
    {
        return _context.Usuarios.Find(id);
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _context.Usuarios.ToList();
    }

    public void Delete(Usuario entity)
    {
        var usuario = GetById(entity.Id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }

    public IEnumerable<NoticiaTag> GetByIdTag(int idTag)
    {
        throw new NotImplementedException();
    }
}
