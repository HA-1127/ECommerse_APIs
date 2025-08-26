using ECommerce.API.DTOs.Responses;
using ECommerce.API.Utility;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Areas.Admin.Controllers
{
    [Route("api[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    public class CategoriesController : ControllerBase
    {
        private ICategoryRepository _categoryRepository;// = new CategoryRepository();

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAsync();

            return Ok(categories);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryRequest categoryRequest)
        {
            await _categoryRepository.CreateAsync(categoryRequest.Adapt<Category>());

            //CookieOptions cookie = new()
            //{

            //};
            //Response.Cookies.Append("success-notification", "Add Category Successfully", cookie);
            

            await _categoryRepository.CommitAsync();

            return Ok("Add Category Successfully");
        }

        [HttpGet("Details/{id}")]

        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var category = await _categoryRepository.GetOneAsync(e => e.Id == id);

            if (category is not null)
            {
                return Ok(category);
            }

            return NotFound();
        }

        [HttpPut("Edit/{id}")]

        public async Task<IActionResult> Edit(int id, CategoryRequest categoryRequest)
        {

            var categoryInDb = await _categoryRepository.GetOneAsync(e => e.Id == id);

            if (categoryInDb is null)
                return NotFound();

            categoryInDb.Name = categoryRequest.Name;
            categoryInDb.Description = categoryRequest.Description;
            categoryInDb.Status = categoryRequest.Status;

           
            await _categoryRepository.CommitAsync();

            return Ok("Update Category Successfully");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryRepository.GetOneAsync(e => e.Id == id);

            if (category is not null)
            {
                _categoryRepository.Delete(category);
                await _categoryRepository.CommitAsync();

                return Ok("Delete Category Successfully");
            }

            return NotFound();

        }
    }
}
