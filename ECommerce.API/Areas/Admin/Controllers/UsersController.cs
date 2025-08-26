using ECommerce.API.DTOs.Responses;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.API.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userManager.Users.ToList();

            return Ok(users.Adapt<IEnumerable<ApplicationUserResponse>>());
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user.Adapt<ApplicationUserResponse>());
        }

        [HttpPatch("LockUnLock/{id}")]
        public async Task<IActionResult> LockUnLock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            if(user.LockoutEnabled)
            {
                user.LockoutEnabled = false;
                user.LockoutEnd = DateTime.UtcNow.AddDays(2);
            }
            else
            {
                user.LockoutEnabled = true;
                user.LockoutEnd = null;
            }

            await _userManager.UpdateAsync(user);

            return Ok("Update successfully");
        }
    }
}
