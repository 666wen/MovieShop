using ApplicationCore.Contract.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService:IGenreService

    {
        //DI generRepository is using Repository<genre> =>Irepository<genre>
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _genreRepository.GetAll();// List(rows)
            // var genresModel = genres.Select(g => new GenreModel { Id = g.Id, Name = g.Name });
            //same as the following codes
            var genresModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genresModel.Add(new GenreModel { Id=genre.Id, Name=genre.Name});
            }
            return genresModel;
        }

        public async Task<bool> AddGenre(string genreName)
        {
            var genreEntity = new Genre
            {
                Name = genreName,
            };
            var genreAdded = await _genreRepository.Add(genreEntity); //return entity
            if (genreAdded.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteGenre(int genreId)
        {
            var delEntity = await _genreRepository.GetGenreById(genreId);

            var delConfirm = await _genreRepository.Delete(delEntity); //delete entity
            if (delConfirm == null)
            {
                return false;
            }
            return true;
        }


    }
}
