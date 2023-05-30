using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webShop.Domain.Entities.Product;


namespace webShop.BussinessLogic.DBModel
{
    public class ProductDbContext : DbContext
    {

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<ProductData> Products { get; set; }
        public DbSet<ProductCart> Cart { get; set; } 
    }
}
