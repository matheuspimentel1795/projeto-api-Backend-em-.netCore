using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task AddCategory(CategoryDTO categoryDto)
        {
            // converto dto em entity
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryId = categoryEntity.CategoryId;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {

           var categoriesEntity = await _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {

            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);

        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntityById = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(categoryEntityById);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetCategoryById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }

        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.Update(categoryEntity);
        }
    }
}
