using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Genre()
        {
            var genres = await _genreService.GetAllGenres();
            return Ok(genres);
        }

        [HttpPost]
        [Route("add-genre")]
        public async Task<IActionResult> AddGenre([FromBody]GenreModel newGenre)
        {
            var addedCheck = await _genreService.AddGenre(newGenre.Name);
            if (addedCheck)
            {
                return Ok(addedCheck);
            }
            return NotFound(new { errorMessage = "Add Genre Failed" });
        }

        [HttpDelete]
        [Route("delete-genre/{genreId:int}")]
        public async Task<IActionResult> DelGenre(int genreId)
        {
            var delGenre = await _genreService.DeleteGenre(genreId);

            if (!delGenre)
            {
                return NotFound(new { errorMessage = "Delete Genre Failed" });
            }
            return Ok(delGenre);
        }

    }
}
