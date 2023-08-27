using BookMergeStore.DAL.IRepository;
using BookMergeStore.DAL.Repository;
using BookMergeStore.Models;
using BookMergeStore.Models.ViewModels;
using BookMergeStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookMergeStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var model = _unitOfWork.Product.GetAll(includeProperties:"Category");

            return View(model);
        }

        //

        public IActionResult UpSert(int? id)
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });

            ProductVM model = new ProductVM
            {
                CategoryList = CategoryList,
                Product = new Product()
            };

            if (id == null || id <= 0)
            {
                return View(model);
            }
            else
            {
                model.Product = _unitOfWork.Product.Get(c => c.Id == id); ;

                if (model.Product == null)
                {
                    return View();
                }

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult UpSert(ProductVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(obj.Product.ImgURL))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.Product.ImgURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImgURL = @"\images\product\" + fileName;
                }

                var existingProduct = _unitOfWork.Product.Get(p => p.Id == obj.Product.Id);

                if (existingProduct == null)
                {
                    _unitOfWork.Product.Create(obj.Product);
                    TempData["success"] = "Created Successfully";
                }
                else
                {

                    _unitOfWork.Product.Update(obj.Product);
                    TempData["success"] = "Edited Successfully";
                }

                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new { data = objProductList });
        }


        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToBeDeleted = _unitOfWork.Product.Get(u => u.Id == id);
            if (productToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            if (productToBeDeleted.ImgURL != null)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                          productToBeDeleted.ImgURL.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            

            _unitOfWork.Product.Remove(productToBeDeleted);
            _unitOfWork.Commit();

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion


    }
}
