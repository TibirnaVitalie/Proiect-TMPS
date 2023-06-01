using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Iterator.Cart
{
     public class CartProductCollection : IEnumerable<ProductCart>
     {
          private List<ProductCart> _products;

          public CartProductCollection(List<ProductCart> products)
          {
               _products = products;
          }

          public IEnumerator<ProductCart> GetEnumerator()
          {
               return new CartProductIterator(_products);
          }

          IEnumerator IEnumerable.GetEnumerator()
          {
               return GetEnumerator();
          }
     }
}
