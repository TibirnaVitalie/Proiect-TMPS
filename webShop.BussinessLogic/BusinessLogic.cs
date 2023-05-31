using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.BussinessLogic.DBModel;
using webShop.BussinessLogic.Interfaces;

namespace webShop.BussinessLogic
{
     public class BusinessLogic
     {
          private static BusinessLogic instance;

          private BusinessLogic()
          {

          }

          public static BusinessLogic GetInstance()
          {
               if (instance == null)
               {
                    instance = new BusinessLogic();
               }
               return instance;
          }
          
          public IProduct GetProductBL(ProductDbContext db)
          {
               return new ProductBL(db);
          }
     }
}
