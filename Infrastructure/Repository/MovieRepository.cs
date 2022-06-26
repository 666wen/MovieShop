using ApplicationCore.Contract.Repository;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        //Repository has a costomed constructor, using that one, do not need overide
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Movie>> Get30HighestRatingMovies()
        {
            throw new NotImplementedException();

        }

        //public IEnumerable<Movie> Get30HightestGrossingMovies()
        public async Task<IEnumerable<Movie>> Get30HightestGrossingMovies()
        {
            //LINQ code to get top 30 grossing movies
            //select top(30) * from MovieTable  order by revenue
            //I/O bound operation
            //var movies = await _dbContext.Movies.OrderByDescending(x=>x.Revenue).Take(30).ToListAsync();
            var movies =await _dbContext.Movies.Take(30).ToListAsync();
            //Movies: check Dbset table defined name in MoviesShopDbContext class
            //return list {{Movie Entity},{row2}...}
            return movies;
        }

        public async override Task<Movie> GetById(int id)
        {
            //select * from Movies Join Cast join MovieCast join Trailer join MovieGenre join Genre
            //where id=id
            //not async
            //var movieDetails =
            //    _dbContext.Movies.Include(m => m.GenresOfMovie).ThenInclude(m => m.Genre)
            //    .Include(m => m.Trailers)
            //    .Include(m => m.MovieCasts).ThenInclude(m=>m.Cast)
            //    .Include(m=>m.Reviews) //join the tableName In Entity Navigation property Name
            //    .FirstOrDefault(m => m.Id == id);

            var movieDetails = await _dbContext.Movies
                .Include(m => m.GenresOfMovie).ThenInclude(m => m.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Reviews) //join the tableName In Entity Navigation property Name
                .FirstOrDefaultAsync(m => m.Id == id); //using Async command
            return movieDetails;
        }

        public async Task<PagedResultSetModel<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            //get total count of movies of this genre
            var totalMoviesForGenre = await _dbContext.MovieGenres.Where(x=>x.Genre.Id == genreId).CountAsync();

            var movies =await  _dbContext.MovieGenres
                .Where(x=>x.Genre.Id == genreId)
                .Include(x => x.Movie) //check entity navigation table name
                .OrderByDescending(x => x.Movie.Revenue)
                .Select(x => new Movie { Id=x.MovieId, PosterUrl=x.Movie.PosterUrl, Title=x.Movie.Title })
                .Skip(pageSize*(pageNumber-1))
                .Take(pageSize).ToListAsync();

            var pagedMovies = new PagedResultSetModel<Movie>(pageNumber, totalMoviesForGenre, pageSize, movies);
            return pagedMovies;



        }
    }
}
