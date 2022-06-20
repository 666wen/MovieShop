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
    public class CastRepository: Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext):base(dbContext)
        {
        }

        public override Cast GetById(int id)  //return Cast entity??
        {
            //select * from Casts Join Cast join MovieCast 
            //where id=id
            var castDetails =
                _dbContext.Casts.Include(m => m.MovieCasts).ThenInclude(m=>m.Movie) //navigation property
                .FirstOrDefault(m => m.Id == id);
            return castDetails;
        }
    }
}
