using Microsoft.EntityFrameworkCore;
using ProductsManagement.Interfaces;
using ProductsManagement.Models;

namespace ProductsManagement.Services
{
    public class ProductMethods: IProductServices
    {
        private ProductDbContext _context;
        
        public ProductMethods(ProductDbContext context)
        {
            _context = context;
        }

        private void DatabaseContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ProductDbContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ProductMs")
            .Options;
            _context = new ProductDbContext(contextOptions);
        }

        private void InMemoryContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ProductDbContext>()
            .UseInMemoryDatabase("Product")
            .Options;
            _context = new ProductDbContext(contextOptions);
        }

        private void ChangeContext(string database)
        {
            if (database.Equals("persistent"))
                DatabaseContext(); 
            else
                InMemoryContext();
        }

        public async Task<List<Product>> GetProducts(string database) 
        {
            ChangeContext(database);
            return await _context.Products.ToListAsync();
        }

        public async Task CreateProduct(Product product, string database)
        {
            ChangeContext(database);
            _context.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}