using PracticeWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using PracticeWebApp.Data;

namespace PracticeWebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> Products = Data.ProductData.Products;
            return View(Products);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Product product)
        {
            ProductData.AddProduct(product);
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product foundproduct = Data.ProductData.Products.Find(product => product.Id == id);
            if (foundproduct == null) { return NotFound(); }
            return View(foundproduct);

        }
        //POST
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductData.UpdateProduct(product);
            TempData["success"] = "Product updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product foundproduct = Data.ProductData.Products.Find(product => product.Id == id);
            if (foundproduct == null) { return NotFound(); }
            ProductData.DeleteProduct(foundproduct);
            return RedirectToAction("Index");

        }

        //POST
        [HttpPost]
        public IActionResult DeletePOST(Product product)
        {
            ProductData.DeleteProduct(product);
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

