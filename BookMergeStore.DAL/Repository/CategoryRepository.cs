using BookMergeStore.DAL.Data;
using BookMergeStore.DAL.IRepository;
using BookMergeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMergeStore.DAL.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category Entity)
        {
            _db.Categories.Update(Entity);
        }
    }
}
