using ProductAPI.Models;

namespace ProductAPI.Repositories.Interfaces
{
    // This interface is a schema for Product Repository class.
    public interface IProductRepository
    {
        // These Tasks will write in Product Repository class.
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(ProductAPI product);
        Task DeleteAsync(ProductAPI product);
        Task SaveChangesAsync();
    }
}