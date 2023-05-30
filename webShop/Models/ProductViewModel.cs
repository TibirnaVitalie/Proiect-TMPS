using webShop.Domain.Entities.Product;

namespace webShop.Models
{
    public class ProductViewModel
    {
        public ProductData ProductData { get; set; }
        public IEnumerable<ProductData> Products { get; set; }
        public IEnumerable<ProductCart> CartProducts { get; set; }
    }
}
