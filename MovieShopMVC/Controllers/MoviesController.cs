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
        public async Task<IActionResult> Details(int idWen)
        {
            var movie =await _movieService.GetMovieDetails(idWen);

            return View(movie);
        }

        public async Task<IActionResult> Genre(int id, int pageSize=30, int pageNumber=1)
        {
            //each time only fetch 30 movies of the picked genre
            var pagedMovies = await _movieService.GetMoviesByGenre(id, pageSize, pageNumber);
            return View("PagedMovies",pagedMovies);
        }
    }
}
