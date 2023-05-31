using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;
using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic.Strategies
{
     public class PriceLowHighSortStrategy : ISortStrategy
     {
          public IEnumerable<ProductData> Sort(IEnumerable<ProductData> data)
          {
               return data.OrderBy(x => x.Price).ToList();
          }
     }
}
