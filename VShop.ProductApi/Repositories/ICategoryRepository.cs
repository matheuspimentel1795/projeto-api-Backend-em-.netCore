using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<IEnumerable<Category>> GetCategoriesProducts();

        Task<Category> GetCategoryById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);

    }
    // o que vem depois de task é o retorno, pode ser um boolean , string etc
}
