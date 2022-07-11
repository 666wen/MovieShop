using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        [Route("add-movie")]
        public async Task<IActionResult> AddMovie([FromBody] MovieModel movie)
        {
            var addConfirm = await _adminService.AddMovie(movie);
            if (addConfirm)
            {
                return Ok(addConfirm);
            }
            return NotFound(new { errorMessage = "Add Movie Failed" });
        }
    }
}
