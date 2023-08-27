using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMergeStore.DAL.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; set; }
        IProductReopsitory Product { get; set; }
        void Commit();
    }
}
