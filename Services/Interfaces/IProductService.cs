using ProductAPI.DTOs;
using ProductAPI.Models;

namespace ProductAPI.Services.Interfaces
{
    // Interface for Product Service class.
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(ProductDto dto);
        Task<bool> DeleteAsync(int id);
    }
}