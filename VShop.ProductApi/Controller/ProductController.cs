using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var produtosDto = await _productsService.GetAll();
            if(produtosDto == null)
                return NotFound("Nenhum produto cadastrado");
            return Ok(produtosDto);
        }
        [HttpGet("{id}",Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var produtoDto = await _productsService.GetProductById(id);
            if(produtoDto == null)
                return NotFound("Produto nao encontrado");
            return produtoDto;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
        {
            if (productDto == null)
                return NotFound("Produto nao encontrado");
            await _productsService.AddProduct(productDto);
            return new CreatedAtRouteResult("GetProduct", new { id =productDto.Id },
                productDto);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] ProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest("id nao existe");
            if (productDto is null)
                return BadRequest("Data invalida");
            await _productsService.Update(productDto);
            return Ok(productDto);
        }
    }
}
