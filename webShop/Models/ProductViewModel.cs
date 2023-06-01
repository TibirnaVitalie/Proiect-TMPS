using webShop.Domain.Entities.Product;
using webShop.BussinessLogic.Iterator.Product;
using webShop.BussinessLogic.Iterator.Cart;

namespace webShop.Models
{
    public class ProductViewModel
    {
        public ProductData ProductData { get; set; }
        public ProductCollection Products { get; set; }
        public CartProductCollection CartProducts { get; set; }
    }
}
