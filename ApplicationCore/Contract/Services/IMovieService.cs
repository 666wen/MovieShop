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
        List<MovieCardModel> GetTopGrossingMovies();

        //get movie details
        MovieDetialsModel GetMovieDetails(int id);


    }
}
