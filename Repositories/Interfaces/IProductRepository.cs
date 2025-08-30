using ProductApi.Models;

namespace ProductApi.Repositories.Interfaces
{
    // This interface is a schema for Product Repository class.
    public interface IProductRepository
    {
        // These Tasks will write in Product Repository class.
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task SaveChangesAsync();
    }
}