using BookMergeStoreRazor_lamp.Data;
using BookMergeStoreRazor_lamp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMergeStoreRazor_lamp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        readonly private ApplicationDbContext _db;
        public List<Category> Categories { get; set; }

        public void OnGet()
        {
        }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
            Categories = _db.Categories.ToList();
        }

    }
}
