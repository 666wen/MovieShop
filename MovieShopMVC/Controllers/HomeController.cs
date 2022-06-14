using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class HomeController : Controller  //inherite from Controller, then being controller.
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet] //default is Get request.
        public IActionResult Index()  //action
        {
            return View();  //go to Views and find same name cshtml file under the folder with the same name as the controler.
        }

        [HttpGet]
        public IActionResult TopRatedMovies() { 

            //call the movie service
            //movie service will call movie repository
            //movie repository will call the database to get the data
            return View(); 
        }

        public IActionResult Privacy()  //action
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error() //action
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}