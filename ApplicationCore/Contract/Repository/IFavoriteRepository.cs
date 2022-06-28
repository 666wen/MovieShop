using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        Task<List<Movie>> GetMoviesByUserId(int userId);
        Task<Favorite> GetFavoriteById(int movieId, int userId);
        
    }
}
