﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.BussinessLogic.DBModel;
using webShop.BussinessLogic.Interfaces;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic
{
     public class ProductBL : IProduct
     {
          private readonly ProductDbContext _db;

          public ProductBL(ProductDbContext db)
          {
               _db = db;
          }

          public IEnumerable<ProductData> GetProducts()
          {
               return _db.Products.ToList();
          }

          public IEnumerable<ProductCart> GetCartContent()
          {
               return _db.Cart.ToList();
          }

          public object GetProduct(int? id)
          {
               return _db.Products.Find(id) ?? throw new Exception("Item with this id does not exist!");
          }

          public void AddProduct(object product)
          {
               ProductData? productData = product as ProductData;

               if (productData != null)
               {
                    _db.Products.Add(productData);
                    _db.SaveChanges();
               }

               else throw new ArgumentNullException(nameof(product) + "should not be null!");
          }

          public void AddToCart(int? id)
          {
               ProductData? productData = _db.Products.Find(id);

               if (productData != null)
               {
                    ProductCart cart = new ProductCartAdapter(productData);
                    _db.Cart.Add(cart);
                    _db.SaveChanges();
               }

               else throw new ArgumentNullException(nameof(productData) + "should not be null!");
          }

          public void RemoveFromCart(int? id)
          {
               var products = _db.Cart.ToList();

               foreach (var obj in products)
               {
                    if(obj.ProductId == id)
                    {
                         _db.Cart.Remove(obj);
                    }
               }

               _db.SaveChanges();
          }

          public void RemoveProduct(int? id)
          {
               if (id == null)
               {
                    throw new ArgumentNullException("No product with this ID!");
               }

               ProductData? productData = _db.Products.Find(id);

               if (productData == null)
               {
                    throw new Exception(nameof(productData) + "should not be null!");
               }

               _db.Products.Remove(productData);
               _db.SaveChanges();

               RemoveFromCart(id);
          }

          public void UpdateProduct(ProductData? productData)
          {

               if (productData != null)
               {
                    _db.Products.Update(productData);
                    _db.SaveChanges();
               }

               else throw new ArgumentNullException(nameof(productData) + "should not be null!");
          }

          public IEnumerable<ProductData> FilterByPrice(int? price)
          {
               List<ProductData> products = _db.Products.ToList();

               if (price == 200)
               {
                    return products.FindAll(
                        delegate (ProductData product)
                        {
                             return product.Price >= 200;
                        }
                    );
               }

               return products.FindAll(
                   delegate (ProductData product)
                   {
                        return product.Price >= price && product.Price < price + 50;
                   }
               );
          }

          public void ClearCart()
          {
               var products = _db.Cart.ToList();

               foreach (var obj in products)
               {
                    _db.Products.Find(obj.ProductId).Ammount -= 1;
               }

               _db.Cart.RemoveRange(_db.Cart);
               _db.SaveChanges();
          }
     }
}
