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
    public class GenreRepostoty : Repository<Genre>, IGenreRepository
    {
        public GenreRepostoty(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Genre> GetGenreById(int genreId)
        {

            var genreEntity = await _dbContext.Genre  //dbContext table name
                .FirstOrDefaultAsync(m => m.Id==genreId); //using Async command
            if (genreEntity == null)
            {
                return null;
            }
            return genreEntity;
        }
    }
}
