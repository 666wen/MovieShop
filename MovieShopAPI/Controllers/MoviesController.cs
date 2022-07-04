using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase //controllerBase do not have Views
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet] //important!!!!!!!!
        [Route("top-grossing")] //attribute routing
        //MVC URL http://localhost/movies/GetTopGrossingMovies traditional/conventional based routing
        //API http://localhost/api/Controller/attribute-routing
        public async Task<IActionResult> GetTopGrossingMovies()
        {

            //call my service
            var movies = await _movieService.GetTopGrossingMovies();

            //**return the movies data in JSON formate along with HTTP status code

            //ASP.NET Core automatically serializes C# onjects to JSON Objects
            //using Library System.Text.Json after .Net 3
            //older version using Newtonsoft.JSON (popular can find in Nuget)
            if(movies == null || !movies.Any())
            {
                //404
                return NotFound(new {errorMessage = "No Movies Found"});
            }
            return Ok(movies); //200
        }

        [HttpGet]
        [Route("{movieId:int}")] //route parameter name shou be same sa inputName
        public async Task<IActionResult> GetMovie(int movieId)
        {
            var movie = await _movieService.GetMovieDetails(movieId);
            if(movie == null)
            {
                return NotFound(new { errorMessage = $"No Movie Found For {movieId}" });
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> Genre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var pagedMovies = await _movieService.GetMoviesByGenre(genreId, pageSize, pageNumber);
            if (pagedMovies == null)
            {
                return NotFound(new { errorMessage = $"No Movie Found For Genre:{genreId}" });
            }
            return Ok(pagedMovies);
        }


    }
}
