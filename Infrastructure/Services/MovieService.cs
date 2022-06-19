using ApplicationCore.Contract.Repository;
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
        private readonly IMovieRepository _movieRepository; //DI
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;     //DI
        }


        public List<MovieCardModel> GetTopGrossingMovies()
        {
            //call the MovieRepository to get the data from database
            //not use: new MovieRepository(),    using DI

            var movies = _movieRepository.Get30HightestGrossingMovies();
            //this movies is list<Movie Entity>
            var movieCards= new List<MovieCardModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;


        }

        public MovieDetialsModel GetMovieDetails(int id)
        {
            var movieDetails = 
            return movieDetails;
        }


    }
}
