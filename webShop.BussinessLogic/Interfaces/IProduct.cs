﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Interfaces
{
    public interface IProduct
    {
        public IEnumerable<ProductData> GetProducts();
        public IEnumerable<ProductCart> GetCartContent();
        public object GetProduct(int? id);
        public void AddProduct(object product);
        public void UpdateProduct(ProductData? productData);
        public void RemoveProduct(int? id);
        public void AddToCart(int? id);
        public void ClearCart();
        public IEnumerable<ProductData> FilterByPrice(int? price);


    }
}
