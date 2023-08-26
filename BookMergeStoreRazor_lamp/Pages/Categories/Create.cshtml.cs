using BookMergeStoreRazor_lamp.Data;
using BookMergeStoreRazor_lamp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMergeStoreRazor_lamp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        readonly private ApplicationDbContext _db;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {

            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(Category);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage("Create");

        }

    }
}
