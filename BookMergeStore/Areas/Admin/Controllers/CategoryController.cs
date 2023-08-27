using BookMergeStore.DAL.Data;
using BookMergeStore.DAL.IRepository;
using BookMergeStore.DAL.Repository;
using BookMergeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMergeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _IUnitOfWork;

        public CategoryController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }

        public IActionResult Index()
        {
            var model = _IUnitOfWork.Category.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _IUnitOfWork.Category.Create(obj);
                _IUnitOfWork.Commit();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            Category? category = _IUnitOfWork.Category.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _IUnitOfWork.Category.Update(obj);
                _IUnitOfWork.Commit();
                TempData["success"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id < 0)
            {
                return NotFound();
            }

            Category? category = _IUnitOfWork.Category.Get(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _IUnitOfWork.Category.Get(c => c.Id == id);

            if (category != null)
            {
                _IUnitOfWork.Category.Remove(category);
                _IUnitOfWork.Commit();
                TempData["success"] = "Deleted Successfully";
            }
            return RedirectToAction("Index");
        }

    }
}
