using BookMergeStore.DAL.Data;
using BookMergeStore.DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookMergeStore.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this._dbSet = _db.Set<T>();
        }


        public virtual void Create(T Entity)
        {
            _dbSet.Add(Entity);
        }

        public virtual T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet.Where(filter);
            return query.FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query.ToList();
        }

        public virtual void Remove(T Entity)
        {
            _db.Remove(Entity);
        }
    }
}
