using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webShop.BussinessLogic;
using webShop.BussinessLogic.DBModel;
using webShop.BussinessLogic.Interfaces;
using webShop.Domain.Entities.Product;
using webShop.BussinessLogic.Iterator.Product;
using webShop.BussinessLogic.Iterator.Cart;
using webShop.BussinessLogic.Strategies;
using webShop.Models;

namespace webShop.Controllers
{
     public class HomeController : Controller
     {
          private readonly ILogger<HomeController> _logger;
          private readonly IProduct _product;
          private ISortStrategy _sorter = new NameSortStrategy();

          public HomeController(ILogger<HomeController> logger, ProductDbContext db)
          {
               _logger = logger;

               BusinessLogic bl = BusinessLogic.GetInstance();
               _product = bl.GetProductBL(db);
          }

          public IActionResult Index()
          {
               ProductCollection _sortedCollection = new ProductCollection(_product.GetProducts() as List<ProductData>);

               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = new ProductCollection(_sorter.Sort(_sortedCollection) as List<ProductData>),
                    CartProducts = new CartProductCollection(_product.GetCartContent() as List<ProductCart>)
               };

               return View(viewModel);
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
               ProductCollection _sortedCollection = new ProductCollection(_product.GetProducts() as List<ProductData>);

               ProductCollection viewModel = new ProductCollection(_sorter.Sort(_sortedCollection) as List<ProductData>);

               return View(viewModel);
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