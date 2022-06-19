using ApplicationCore.Contract.Repository;
using ApplicationCore.Entities;
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

        public IEnumerable<Movie> Get30HighestRatingMovies()
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Movie> Get30HightestGrossingMovies()
        {
            //LINQ code to get top 30 grossing movies
            //select top(30) * from MovieTable  order by revenue
            //var movies = _dbContext.Movies.OrderByDescending(x=>x.Revenue).Take(30).ToList();
            var movies = _dbContext.Movies.Take(50).ToList();
            //Movies: check Dbset table defined name in MoviesShopDbContext class
            //return list {{Movie Entity},{row2}...}
            return movies;
        }

        public override Movie GetById(int id)
        {
            //select * from Movies Join Cast join MovieCast join Trailer join MovieGenre join Genre
            //where id=id
            var movieDetails =
                _dbContext.Movies.Include(m => m.GenresOfMovie).ThenInclude(m => m.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.MovieCasts).ThenInclude(m=>m.Cast)
                .FirstOrDefault(m => m.Id == id);
            return movieDetails;
        }

    }
}
