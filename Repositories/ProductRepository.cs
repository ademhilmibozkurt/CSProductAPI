using Microsoft.EntityFrameworkCore;
using ProductApi.Models;
using ProductApi.Data;
using ProductApi.Repositories.Interfaces;
using System.ComponentModel;

namespace ProductApi.Repositories
{
	// This class implements IProductRepositorry interface for repository operations.
	public class ProductRepository : IProductRepository
	{
		private readonly AppDbContext _context;
		public ProductRepository(AppDbContext context) => _context = context;

		public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();
		public async Task<Product?> GetByIdAsync(int id) => await _context.Products.FindAsync(id);
		
		public async Task<Product> AddAsync(Product product)
		{
			await _context.Products.AddAsync(product);
			return product;
		}

		public Task DeleteAsync(Product product)
		{
			_context.Products.Remove(product);
			return Task.CompletedTask;
		}
		public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
	}
}