using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private ICastService _castService;
        public CastController(ICastService castService)
        {
            _castService = castService;
        }
        public IActionResult CastDetails(int idCast)
        {
            var castDetails= _castService.GetCastDetails(idCast);
            return View(castDetails);
        }
    }
}
