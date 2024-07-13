using AspNetCoreMvc_EFCore_Stock.Models;
using AspNetCoreMvc_EFCore_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspNetCoreMvc_EFCore_Stock.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository _productRepo = new ProductRepository();
        CategoryRepository _categoryRepo = new CategoryRepository();

        public IActionResult List(string? search)
        {
            var products = _productRepo.GetAll();
            if(search != null)
            {
                products = products.Where(p => p.Name.ToLower().Contains(search.ToLower().Trim())).ToList();
            }
            return View(products);
        }
        public IActionResult Index(int? id)     //id -> categoryId
        {
            var products = _productRepo.GetAll();
            if(id != null)
                products = products.Where(p => p.CategoryId == id).ToList();

            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _productRepo.GetById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryRepo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product model)
        {
            _productRepo.Add(model);  //Formdan gelen Product modelini veritabanına ekler.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryRepo.GetAll(), "Id", "Name");
            var product = _productRepo.GetById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            _productRepo.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _productRepo.GetById(id);
            _productRepo.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
