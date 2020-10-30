using System.Collections.Generic;

namespace EAuction.WebApp.Data
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
