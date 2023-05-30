using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webShop.Domain.Entities.Product;

namespace webShop.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50), Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Product Category")]
        public string Category { get; set; }

        [Required, Display(Name = "Product Price")]
        public int Price { get; set; }

        [Required, Display(Name = "Product Currency")]
        public char Currency { get; set; }

        [Required, Display(Name = "Product Ammount")]
        public int Ammount { get; set; }

        [Required, Display(Name = "Product Description")]
        public string Description { get; set; }
        public IFormFile Image_1 { get; set; }
        public IFormFile Image_2 { get; set; }
        public IFormFile Image_3 { get; set; }

    }
}
