using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;

namespace webShop.BussinessLogic.Interfaces
{
     public interface ISortStrategy
     {
          public IEnumerable<ProductData> Sort(IEnumerable<ProductData> data);
     }
}