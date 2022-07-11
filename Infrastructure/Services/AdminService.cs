using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
   public class AdminService:IAdminService
    {
        private readonly IMovieRepository _movieRepository;
        public AdminService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> AddMovie(MovieModel movie)
        {
            var movieEntity = new Movie
            {
                Title = movie.Title,
                Overview = movie.Overview,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                PosterUrl = movie.PosterUrl,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                RunTime = movie.RunTime,
                Price = movie.Price,
                CreatedDate = movie.CreatedDate,
                //UpdatedDate = movie.UpdatedDate,
                //UpdatedBy = movie.UpdatedBy,
                CreatedBy = movie.CreatedBy
            };
            var addedMovie = await _movieRepository.Add(movieEntity);
            if (addedMovie.Id > 0)
            {
                return true;
            }
            return false;
        }
    }
}
