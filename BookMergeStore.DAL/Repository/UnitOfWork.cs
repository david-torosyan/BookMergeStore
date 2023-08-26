using BookMergeStore.DAL.Data;
using BookMergeStore.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMergeStore.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get ; set ; }

        public UnitOfWork(ApplicationDbContext db)
        {
                _db = db;
                Category = new CategoryRepository(db);
        }

        public void Commit()
        {
            _db.SaveChanges();
        }
    }
}
