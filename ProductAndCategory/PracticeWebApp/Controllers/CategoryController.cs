using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Data;
using PracticeWebApp.Models;

namespace PracticeWebApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            List<Category> categories = Data.CategoryData.Categories;
            return View(categories);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Category category)
        {
            CategoryData.AddCategory(category);
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category foundcategory = Data.CategoryData.Categories.Find(category => category.Id == id);
            if(foundcategory == null) { return NotFound(); }
            return View(foundcategory);

        }
        //POST
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoryData.UpdateCategory(category);
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category foundcategory = Data.CategoryData.Categories.Find(category => category.Id == id);
            if (foundcategory == null) { return NotFound(); }
            CategoryData.DeleteCategory(foundcategory);
            return RedirectToAction("Index");

        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(Category category)
        {
            CategoryData.DeleteCategory(category);
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
