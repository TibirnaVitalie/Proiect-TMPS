using webShop.Domain.Entities.Product;

namespace webShop.Domain.Interfaces
{
     public interface IProductPrototype
     {
          ProductData Clone();
     }
}
