using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categoryDto = await _categoryService.GetCategories();
            if(categoryDto is null)
                return NotFound();
            return Ok(categoryDto);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesProducts()
        {
            var categoryDto = await _categoryService.GetCategoriesProducts();
            if (categoryDto is null)
                return NotFound();
            return Ok(categoryDto);
        }
        [HttpGet("{id:int}",Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categoryDto = await _categoryService.GetCategoryById(id);
            if (categoryDto is null)
                return NotFound("Categoria não encontrada.");
            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDto)
        {
            if (categoryDto is null)
                return NotFound("payload inválido.");
            await _categoryService.AddCategory(categoryDto);
            return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoryId },
                categoryDto);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id, [FromBody] CategoryDTO categoryDto)
        {
            if(id != categoryDto.CategoryId)
                return BadRequest();
            if (categoryDto is null)
                return BadRequest();
            await _categoryService.UpdateCategory(categoryDto);
            return Ok(categoryDto);
        }
    }
}

