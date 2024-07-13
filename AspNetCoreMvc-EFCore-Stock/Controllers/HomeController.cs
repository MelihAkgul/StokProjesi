using AspNetCoreMvc_EFCore_Stock.Data;
using AspNetCoreMvc_EFCore_Stock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCoreMvc_EFCore_Stock.Controllers
{
    public class HomeController : Controller
    {
        /*StockDbContext _context = new StockDbContext();*/     //veritabanýna karþýlýk

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var categories = _context.Categories.ToList();

            //return View(categories);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
