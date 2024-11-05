using App.Domain.Entities;

namespace App.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<NoticiaTag> GetByIdTag(int idTag);
    }
}
