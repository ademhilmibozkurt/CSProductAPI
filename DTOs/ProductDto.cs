namespace ProductApi.DTOs
{
    public class ProductDto
    {
        // Data Transfer Object used for encapsulate data and send it from one part of an application to another.
        // In our case, we use it for db operations.
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}