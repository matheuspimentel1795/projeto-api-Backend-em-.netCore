using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        Task<ProductDTO> GetProductById(int id);
        Task AddProduct(ProductDTO productDto);
        Task Update(ProductDTO productDto);
        Task Delete(int id);
    }
}
