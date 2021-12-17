using Microsoft.EntityFrameworkCore;

namespace ProductsManagement.Models
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> contextOptions)
        : base(contextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}