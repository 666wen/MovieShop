using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        private ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Route("{idCast}")]
        public async Task<IActionResult> CastDetails(int idCast)
        {
            var castDetails = await _castService.GetCastDetails(idCast);
            if (castDetails == null)
            {
                return NotFound(new { errorMessage = $"No Cast found with id: {idCast}" });
            }
            return Ok(castDetails);
            
        }
    }
}
