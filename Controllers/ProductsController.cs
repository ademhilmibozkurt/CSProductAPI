using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Services.Interfaces;

namespace ProductAPI.Controllers
{
    // routing
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllersBase
    {
        // Dependency Injection
        private readonly IProductService _service;
        public ProductsController(IProductService service) => _service = service;
    
        // Get Request
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        // Get request with id parameter
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            return product is not null ? Ok(product) : NotFound();
        }

        // Post request
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            var product = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // Delete request with id parameter
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}