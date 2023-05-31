using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webShop.BussinessLogic;
using webShop.BussinessLogic.DBModel;
using webShop.BussinessLogic.Interfaces;
using webShop.Domain.Entities.Product;
using webShop.Models;

namespace webShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProduct _product;

        public HomeController(ILogger<HomeController> logger, ProductDbContext db)
        {
            _logger = logger;

            BusinessLogic bl = BusinessLogic.GetInstance();
            _product = bl.GetProductBL(db);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Authorize]
        public IActionResult Maintenance()
        {
            return View();
        }

        public IActionResult Search(string name)
        {
            List<ProductData> products = new List<ProductData>();

            foreach (var obj in _product.GetProducts())
            {
                if (obj.Name.Contains(name))
                {
                    products.Add(obj);
                }
            }

            return View("Index", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}