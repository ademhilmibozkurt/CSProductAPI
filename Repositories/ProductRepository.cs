using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Models;
using ProductAPI.Repositories.Interfaces;

namespace ProductAPI.Repositories
{
	// This class implements IProductRepositorry interface for repository operations.
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context) => _context = context;

		public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
		public async Task<Product?> GetByIdAsync(int id) => await _context.Product.FindAsync(id);
		
		public async Task<Product> AddAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			return product;
		}

		public async Task DeleteAsync(Product product) => _context.Products.Remove(product);
		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
	}
}