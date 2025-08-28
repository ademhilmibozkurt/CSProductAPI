using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Data
{
    // Creating a object that inherit DbContext for database entity collection.
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        // Products is a set of Product objects.
        public DbSet<Product> Products => Set<Product>();
    }
}