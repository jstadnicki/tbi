namespace ToBeImplemented.Infrastructure.Interfaces
{
    using System.Linq;

    using ToBeImplemented.Domain.Model;

    public interface ITbiRepository<T> where T : ITbiEntity
    {
        IQueryable<T> All();
        void Create(T entity);
        T Find(long id);
        void Update(T entity);
        void Remove(T entity);
    }
}
