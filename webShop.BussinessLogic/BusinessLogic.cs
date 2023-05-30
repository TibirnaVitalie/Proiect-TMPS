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
        public IProduct GetProductBL(ProductDbContext db)
        {
            return new ProductBL(db);
        }
    }
}
