 namespace VShop.ProductApi.Models
{
    public class Product
    {
        public int Id { get;set; }
        public string? Name { get; set; } // interrogacaao na frente pois podem ser null
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; } // relacionarmento com categoria
        public int CategoryId { get; set; }

    }
}
