using AutoMapper;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productsRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }

        public async Task Delete(int id)
        {
            var productyEntity = _productsRepository.GetProductById(id).Result;
            await _productsRepository.Delete(productyEntity.Id);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var productEntity = await _productsRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productEntity);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var productEntity = await _productsRepository.GetProductById(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productsRepository.Update(productEntity);
        }
    }
}
