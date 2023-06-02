using System.ComponentModel.DataAnnotations;
using webShop.Domain.Interfaces;

namespace webShop.Domain.Entities.Product
{
     public class ProductData : IProductPrototype
     {
          [Key]
          public int Id { get; set; }

          [Required]
          [StringLength(50)]
          public string Name { get; set; }

          [Required]
          public string Category { get; set; }

          [Required]
          public int Price { get; set; }

          [Required]
          public int Ammount { get; set; }

          [Required]
          public string Description { get; set; }
          public string ImageName_1 { get; set; }
          public string ImageName_2 { get; set; }
          public string ImageName_3 { get; set; }

          public ProductData()
          {
          }

          public ProductData(ProductData other)
          {
               this.Name = other.Name;
               this.Category = other.Category;
               this.Price = other.Price;
               this.Ammount = other.Ammount;
               this.Description = other.Description;
               this.ImageName_1 = other.ImageName_1;
               this.ImageName_2 = other.ImageName_2;
               this.ImageName_3 = other.ImageName_3;
          }

          public ProductData Clone()
          {
               return new ProductData(this);
          }
     }
}
