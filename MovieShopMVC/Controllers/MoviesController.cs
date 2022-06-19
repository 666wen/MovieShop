using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        //show details of the movie
        public IActionResult Details(int idWen)
        {
            

            return View();
        }
    }
}
