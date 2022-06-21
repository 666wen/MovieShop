using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface IMovieService
    {
        //all the business functionality methods pertaining to movies
        //not Async
        //List<MovieCardModel> GetTopGrossingMovies();
        //MovieDetialsModel GetMovieDetails(int id);

        Task<List<MovieCardModel>> GetTopGrossingMovies();
        Task<MovieDetialsModel> GetMovieDetails(int id);


    }
}
