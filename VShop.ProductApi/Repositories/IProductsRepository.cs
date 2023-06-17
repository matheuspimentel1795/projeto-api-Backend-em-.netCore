using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetProductById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);

    }
}
