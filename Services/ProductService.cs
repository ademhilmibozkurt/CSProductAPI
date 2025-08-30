using ProductApi.DTOs;
using ProductApi.Models;
using ProductApi.Repositories.Interfaces;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    // ProductService implements IProductService interface
    public class ProductService : IProductService
    {
        // Dependency Injection using for outer objects not creating internally.
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<IEnumerable<Product>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Product?> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        // Creating a product.
        public async Task<Product> CreateAsync(ProductDto dto)
        {
            var product = new Product
            {
                Name  = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
            return product;
        }

        // Deleting a product with its id.
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;
            await _repo.DeleteAsync(product);
            await _repo.SaveChangesAsync();
            return true;
        }

    }
}