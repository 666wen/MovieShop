using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IMovieRepository: IRepository<Movie>
    {
        //all the database logic methods for Movie
        //working with Movie Entity
        IEnumerable<Movie> Get30HightestGrossingMovies();
        IEnumerable<Movie> Get30HighestRatingMovies();
    }
}
