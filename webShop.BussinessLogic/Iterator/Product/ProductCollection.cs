using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Iterator.Product
{
     public class ProductCollection : IEnumerable<ProductData>
     {
          private List<ProductData> _products;

          public ProductCollection(List<ProductData> products)
          {
               _products = products;
          }

          public IEnumerator<ProductData> GetEnumerator()
          {
               return new ProductIterator(_products);
          }

          IEnumerator IEnumerable.GetEnumerator()
          {
               return GetEnumerator();
          }

          public IEnumerable<ProductData> NameSort()
          {
               return _products.OrderBy(x => x.Name).ToList();
          }

          public IEnumerable<ProductData> PriceLowHighSort()
          {
               return _products.OrderBy(x => x.Price).ToList();
          }

          public IEnumerable<ProductData> PriceHighLowSort()
          {
               return _products.OrderByDescending(x => x.Price).ToList();
          }
     }
}
