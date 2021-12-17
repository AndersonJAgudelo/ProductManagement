using ProductsManagement.Models;

namespace ProductsManagement.Interfaces
{
    public interface IProductServices
    {
        Task<List<Product>> GetProducts(string database);
        Task CreateProduct(Product product, string database);
    }
}