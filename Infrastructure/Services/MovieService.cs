using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    //mothod that return top movies to the caller
    //List of movies
    public class MovieService:IMovieService
    {
        public MovieDetialsModel GetMovieDetails(int id)
        {
            var movieDetails = new MovieDetialsModel();
            return movieDetails;
        }

        public List<MovieCardModel> GetTopGrossingMovies()
        {
            //call the movie repository to get the data from database
            var movies = new List<MovieCardModel>
            {
                new MovieCardModel{ Id=1, PosterUrl="", Title=""},
                new MovieCardModel{ Id=2, PosterUrl="", Title=""},
                new MovieCardModel{ Id=3, PosterUrl="", Title=""},
                new MovieCardModel{ Id=4, PosterUrl="", Title=""},
                new MovieCardModel{ Id=5, PosterUrl="", Title=""}
            };
            return movies;
        }


    }
}
