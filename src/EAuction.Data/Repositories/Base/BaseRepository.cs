using System.Collections.Generic;

namespace EAuction.WebApp.Data
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly EAuctionContext _context;

        public BaseRepository(EAuctionContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> GetAll
            => _context.Set<T>();

        public virtual T GetById(int id)
            => _context.Find<T>(id);

        public virtual void Insert(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
