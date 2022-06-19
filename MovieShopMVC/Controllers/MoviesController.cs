using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        //DI
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //show details of the movie
        public IActionResult Details(int idWen)
        {
            var movie = _movieService.GetMovieDetails(idWen);

            return View(movie);
        }
    }
}
