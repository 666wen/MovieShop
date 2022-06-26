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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository; //DI
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;     //DI
        }


        public async Task<List<MovieCardModel>> GetTopGrossingMovies()
        {
            //call the MovieRepository to get the data from database
            //not use: new MovieRepository(),    using DI

            var movies = await _movieRepository.Get30HightestGrossingMovies();
            //this movies is list<Movie Entity>
            var movieCards = new List<MovieCardModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel { Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title });
            }
            return movieCards;


        }

        public async Task<MovieDetialsModel> GetMovieDetails(int id)
        {
            var movieDetails =await _movieRepository.GetById(id);//entity type
            var movie = new MovieDetialsModel
            {
                Id = movieDetails.Id,
                Tagline = movieDetails.Tagline,
                Title = movieDetails.Title,
                Overview = movieDetails.Overview,
                Budget = movieDetails.Budget,
                PosterUrl = movieDetails.PosterUrl,
                BackdropUrl = movieDetails.BackdropUrl,
                ImdbUrl = movieDetails.ImdbUrl,
                RunTime = movieDetails.RunTime,
                TmdbUrl = movieDetails.TmdbUrl,
                Revenue = movieDetails.Revenue,
                ReleaseDate = movieDetails.ReleaseDate,
                Price = movieDetails.Price,
                Ave_rating=0.0m
            };

            foreach (var genre in movieDetails.GenresOfMovie) //join table Icollection name
            {
                movie.Genres.Add(new GenreModel { Id = genre.GenreId, Name = genre.Genre.Name }); //Name from thenInclude Table, need to indicate this subtable name
            }

            foreach (var trailer in movieDetails.Trailers)
            {
                movie.Trailers.Add(new TrailerModel { Id = trailer.Id, Name = trailer.Name, TrailerUrl = trailer.TrailerUrl });
            }

            foreach (var cast in movieDetails.MovieCasts)
            {
                movie.Casts.Add(new CastModel { Character = cast.Character, Id = cast.Cast.Id, Name = cast.Cast.Name, ProfilePath = cast.Cast.ProfilePath });
            }

            int count=0;
            foreach (var review in movieDetails.Reviews)
            {
                movie.Reviews.Add(new ReviewModel { MovieId = review.MovieId, UserId = review.UserId, Rating = review.Rating, ReviewText = review.ReviewText });
                movie.Ave_rating += review.Rating;
                count++;
            }
            //one movie => multiple reviews, calculate average rating in MovieService
            if (count > 0)
            {
                movie.Ave_rating /= count; //incase divide by 0 exception.
            }
            


            return movie;

        }

        public async Task<PagedResultSetModel<MovieCardModel>> GetMoviesByGenre(int genreId, int pageSize=30, int pageNumber=1)
        {
            var movies =await _movieRepository.GetMoviesByGenre(genreId, pageSize, pageNumber);

            var movieCards = new List<MovieCardModel>();
            foreach (var movie in movies.PagedData)
            {
                movieCards.Add(new MovieCardModel { Id=movie.Id, PosterUrl = movie.PosterUrl, Title=movie.Title });

            }

            return new PagedResultSetModel<MovieCardModel>(pageNumber, movies.TotalRecords, pageSize, movieCards);
      
        }
    }
}
