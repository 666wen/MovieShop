using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
        Task<bool> AddGenre(string genreName);
       Task<bool> DeleteGenre(int genreId);
    }
}
