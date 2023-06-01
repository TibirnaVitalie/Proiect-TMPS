using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Iterator.Product
{
     public class ProductIterator : IEnumerator<ProductData>
     {
          private List<ProductData> _products;
          private int _currentIndex;

          public ProductIterator(List<ProductData> products)
          {
               _products = products;
               _currentIndex = -1;
          }

          public ProductData Current
          {
               get { return _products[_currentIndex]; }
          }

          object IEnumerator.Current => Current;

          public bool MoveNext()
          {
               _currentIndex++;
               return _currentIndex < _products.Count;
          }

          public void Reset()
          {
               _currentIndex = -1;
          }

          public void Dispose()
          {
               
          }
     }
}
