using ApplicationCore.Contract.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Views.Shared.Components.Genres
{
    public class GenresViewComponent:ViewComponent
    {
        //DI
        private readonly IGenreService _genreService;
        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenres();
            return View(genres);
        }

    }
}
