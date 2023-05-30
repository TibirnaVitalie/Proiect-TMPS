using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webShop.Domain.Entities.Product
{
    public class ProductCart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }

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
