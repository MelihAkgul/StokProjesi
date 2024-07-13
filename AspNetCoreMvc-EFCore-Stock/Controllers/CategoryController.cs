using AspNetCoreMvc_EFCore_Stock.Models;
using AspNetCoreMvc_EFCore_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_EFCore_Stock.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepo = new CategoryRepository();
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAll();

            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            _categoryRepo.Add(model);  //Formdan gelen Category modelini veritabanına ekler.
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryRepo.GetById(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            _categoryRepo.Update(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.GetById(id);
            _categoryRepo.Delete(category);
            return RedirectToAction("Index");
            //var category = _categoryRepo.GetById(id);
            //return View(category);
        }
        //[HttpPost]
        //public IActionResult Delete(Category model)
        //{
        //    _categoryRepo.Delete(model);
        //    return RedirectToAction("Index");
        //}
    }
}
