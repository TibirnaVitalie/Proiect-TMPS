using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;
using webShop.BussinessLogic.Interfaces;
using webShop.BussinessLogic.Iterator.Product;

namespace webShop.BussinessLogic.Strategies
{
     public class NameSortStrategy : ISortStrategy
     {
          public IEnumerable<ProductData> Sort(ProductCollection data)
          {
               return data.NameSort();
          }
     }
}
