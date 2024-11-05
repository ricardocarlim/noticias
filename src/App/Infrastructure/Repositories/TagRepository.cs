// Infrastructure/Data/Repositories/NoticiaRepository.cs
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class TagRepository : IRepository<Tag>
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }

    public int Add(Tag entity)
    {
        _context.Tags.Add(entity);
        _context.SaveChanges();
        return entity.Id;
    }

    public void Update(Tag entity)
    {
        _context.Tags.Update(entity);
        _context.SaveChanges();
    }
    
    public Tag GetById(int id)
    {
        return _context.Tags.Find(id);
    }

    public IEnumerable<Tag> GetAll()
    {
        return _context.Tags.ToList();
    }

    public void Delete(Tag entity)
    {
        var tag = GetById(entity.Id);
        if (tag != null)
        {
            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }

    public IEnumerable<NoticiaTag> GetByIdTag(int idTag)
    {
        throw new NotImplementedException();
    }
}
