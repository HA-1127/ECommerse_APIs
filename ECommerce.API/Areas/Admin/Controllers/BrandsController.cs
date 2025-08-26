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
    public class BrandsController : ControllerBase
    {
        private IBrandRepository _brandRepository;// = new BrandRepository();

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            var brands = await _brandRepository.GetAsync();

            return Ok(brands);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(BrandRequest brandRequest)
        {
            await _brandRepository.CreateAsync(brandRequest.Adapt<Brand>());

            //CookieOptions cookie = new()
            //{

            //};
            //Response.Cookies.Append("success-notification", "Add Brand Successfully", cookie);
            

            await _brandRepository.CommitAsync();

            return Ok("Add Brand Successfully");
        }

        [HttpGet("Details/{id}")]

        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var brand = await _brandRepository.GetOneAsync(e => e.Id == id);

            if (brand is not null)
            {
                return Ok(brand);
            }

            return NotFound();
        }

        [HttpPut("Edit/{id}")]

        public async Task<IActionResult> Edit(int id, BrandRequest brandRequest)
        {

            var brandInDb = await _brandRepository.GetOneAsync(e => e.Id == id);

            if (brandInDb is null)
                return NotFound();

            brandInDb.Name = brandRequest.Name;
            brandInDb.Description = brandRequest.Description;
            brandInDb.Status = brandRequest.Status;

           
            await _brandRepository.CommitAsync();

            return Ok("Update Brand Successfully");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var brand = await _brandRepository.GetOneAsync(e => e.Id == id);

            if (brand is not null)
            {
                _brandRepository.Delete(brand);
                await _brandRepository.CommitAsync();

                return Ok("Delete Brand Successfully");
            }

            return NotFound();

        }
    }
}
