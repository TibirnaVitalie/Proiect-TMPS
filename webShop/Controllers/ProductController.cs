using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webShop.BussinessLogic;
using webShop.BussinessLogic.DBModel;
using webShop.BussinessLogic.Interfaces;
using webShop.BussinessLogic.Strategies;
using webShop.Domain.Entities.Product;
using webShop.Domain.Interfaces;
using webShop.Models;

namespace webShop.Controllers
{
     public class ProductController : Controller
     {
          private readonly IProduct _product;
          private readonly IWebHostEnvironment _webHost;
          private ISortStrategy _sorter = new NameSortStrategy();

          public ProductController(ProductDbContext db, IWebHostEnvironment webHost)
          {
               _webHost = webHost;

               BusinessLogic bl = BusinessLogic.GetInstance();
               _product = bl.GetProductBL(db);
          }

          public IActionResult Index()
          {
               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = _sorter.Sort(_product.GetProducts()),
                    CartProducts = _product.GetCartContent()
               };

               return View(viewModel);
          }

          [Authorize]
          public IActionResult Add()
          {
               return View();
          }

          public IActionResult ShopingCart()
          {
               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = new List<ProductData>(),
                    CartProducts = _product.GetCartContent()
               };

               return View(viewModel);
          }

          public IActionResult Buy()
          {
               _product.ClearCart();

               return RedirectToAction("Index");
          }

          public IActionResult ProductDetail(int? id)
          {
               if (id == null)
               {
                    return NotFound();
               }

               ProductViewModel model = new ProductViewModel
               {
                    ProductData = _product.GetProduct(id) as ProductData,
                    Products = _product.GetProducts()
               };

               return View(model);
          }

          public IActionResult AddCart(int? id)
          {
               if (id != null)
               {
                    _product.AddToCart(id);
               }

               return RedirectToAction("ShopingCart");

          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult Add(Product product)
          {
               if (ModelState.IsValid)
               {
                    ProductData productData = new ProductData()
                    {
                         Name = product.Name,
                         Price = product.Price,
                         Category = product.Category,
                         Currency = product.Currency,
                         Ammount = product.Ammount,
                         Description = product.Description,
                         ImageName_1 = product.Image_1.FileName,
                         ImageName_2 = product.Image_2.FileName,
                         ImageName_3 = product.Image_3.FileName,
                    };

                    List<IFormFile> images = new List<IFormFile>();

                    images.Add(product.Image_1);
                    images.Add(product.Image_2);
                    images.Add(product.Image_3);

                    foreach (var obj in images)
                    {
                         string uploadPath = System.IO.Path.Combine(_webHost.WebRootPath + @"\assets\images\" + obj.FileName);

                         using (FileStream file = new FileStream(uploadPath, FileMode.Create))
                         {
                              obj.CopyTo(file);
                         }
                    }

                    _product.AddProduct(productData);
                    return RedirectToAction("Index");
               }

               return View(product);
          }

          [Authorize]
          public IActionResult Duplication(int? id)
          {
               if (id != null)
               {
                    ProductData productData = _product.GetProduct(id) as ProductData;

                    ProductData ClonedProductData = productData.Clone();

                    _product.AddProduct(ClonedProductData);
               }

               return RedirectToAction("Index");

          }

          public IActionResult Remove(int? id)
          {
               _product.RemoveProduct(id);
               return RedirectToAction("Edit");
          }

          [Authorize]
          public IActionResult Edit()
          {
               return View(_product.GetProducts());
          }

          [Authorize]
          public IActionResult Update(int? id)
          {
               if (id == null)
                    return NotFound();

               ProductData? productData = _product.GetProduct(id) as ProductData;

               Product product = new Product
               {
                    Id = productData.Id,
                    Name = productData.Name,
                    Price = productData.Price,
                    Ammount = productData.Ammount,
                    Category = productData.Category,
                    Description = productData.Description,
                    Currency = productData.Currency
               };

               return View("Update", product);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public IActionResult Update(Product product)
          {
               ModelState.Remove("Image_1");
               ModelState.Remove("Image_2");
               ModelState.Remove("Image_3");

               if (ModelState.IsValid)
               {
                    string uploadPath = String.Empty;
                    string deletePath = String.Empty;

                    ProductData? productData = new ProductData()
                    {
                         Id = product.Id,
                         Name = product.Name,
                         Price = product.Price,
                         Ammount = product.Ammount,
                         Category = product.Category,
                         Description = product.Description,
                         Currency = product.Currency,
                    };

                    if (product.Image_1 != null)
                    {
                         deletePath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_1);

                         if (System.IO.File.Exists(deletePath))
                         {
                              System.IO.File.Delete(deletePath);
                         }

                         productData.ImageName_1 = product.Image_1.FileName;

                         uploadPath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_1);

                         using (FileStream file = new FileStream(uploadPath, FileMode.Create))
                         {
                              product.Image_1.CopyTo(file);
                         }
                    }

                    if (product.Image_2 != null)
                    {
                         deletePath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_2);

                         if (System.IO.File.Exists(deletePath))
                         {
                              System.IO.File.Delete(deletePath);
                         }

                         productData.ImageName_2 = product.Image_2.FileName;

                         uploadPath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_2);

                         using (FileStream file = new FileStream(uploadPath, FileMode.Create))
                         {
                              product.Image_2.CopyTo(file);
                         }
                    }

                    if (product.Image_3 != null)
                    {
                         deletePath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_3);

                         if (System.IO.File.Exists(deletePath))
                         {
                              System.IO.File.Delete(deletePath);
                         }

                         productData.ImageName_3 = product.Image_3.FileName;

                         uploadPath = Path.Combine(_webHost.WebRootPath + @"\assets\images\" + productData.ImageName_3);

                         using (FileStream file = new FileStream(uploadPath, FileMode.Create))
                         {
                              product.Image_3.CopyTo(file);
                         }
                    }

                    _product.UpdateProduct(productData);
                    return RedirectToAction("Index");
               }

               return View(product);
          }

          public IActionResult Search(string name, string viewname = "Index")
          {
               List<ProductData> products = new List<ProductData>();

               foreach (var obj in _product.GetProducts())
               {
                    if (obj.Name.Contains(name))
                    {
                         products.Add(obj);
                    }
               }

               return View(viewname, products);
          }

          public void SetSortingStrategy(ISortStrategy sorter)
          {
               _sorter = sorter;
          }

          public IActionResult SortName()
          {
               SetSortingStrategy(new NameSortStrategy());

               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = _sorter.Sort(_product.GetProducts()),
                    CartProducts = _product.GetCartContent()
               };

               return View("Index", viewModel);
          }
          public IActionResult SortLowHigh()
          {
               SetSortingStrategy(new PriceLowHighSortStrategy());

               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = _sorter.Sort(_product.GetProducts()),
                    CartProducts = _product.GetCartContent()
               };

               return View("Index", viewModel);
          }
          public IActionResult SortHighLow()
          {
               SetSortingStrategy(new PriceHighLowSortStrategy()); 
               
               ProductViewModel viewModel = new ProductViewModel()
               {
                    ProductData = new ProductData(),
                    Products = _sorter.Sort(_product.GetProducts()),
                    CartProducts = _product.GetCartContent()
               };

               return View("Index", viewModel);
          }

          public IActionResult FilterPrice(int? price)
          {
               if (price == null)
               {
                    return NotFound();
               }

               return View(_product.FilterByPrice(price));
          }
     }
}
