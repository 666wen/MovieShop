using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
