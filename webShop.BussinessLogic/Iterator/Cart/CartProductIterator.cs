using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Iterator.Cart
{
     public class CartProductIterator : IEnumerator<ProductCart>
     {
          private List<ProductCart> _products;
          private int _currentIndex;

          public CartProductIterator(List<ProductCart> products)
          {
               _products = products;
               _currentIndex = -1;
          }

          public ProductCart Current
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
