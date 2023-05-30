using System.ComponentModel.DataAnnotations;

namespace webShop.Domain.Entities.Product
{
    public class ProductData
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
        public char Currency { get; set; }

        [Required]
        public int Ammount { get; set; }

        [Required]
        public string Description { get; set; }
        public string ImageName_1 { get; set; }
        public string ImageName_2 { get; set; }
        public string ImageName_3 { get; set; }

    }
    
}
