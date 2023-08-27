using BookMergeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMergeStore.DAL.IRepository
{
    public interface IProductReopsitory : IRepository<Product>
    {
        void Update(Product Entity);
    }
}
