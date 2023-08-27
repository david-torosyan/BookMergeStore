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
    internal class ProductRepository : Repository<Product>, IProductReopsitory
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product Entity)
        {
           _db.Products.Update(Entity);
        }
    }
}
