using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webShop.Domain.Entities.Product
{
    public class ProductCartAdapter: ProductCart
    {
          private ProductData _productData;

          public ProductCartAdapter(ProductData productData)
          {
               _productData = productData;
               ProductId = _productData.Id;
               Name = _productData.Name;
               Category = _productData.Category;
               Price = _productData.Price;
               Ammount = _productData.Ammount;
               Description = _productData.Description;
               ImageName_1 = _productData.ImageName_1;
               ImageName_2 = _productData.ImageName_2;
               ImageName_3 = _productData.ImageName_2;
          }
    }
}
