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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContaxt) : base(dbContaxt)
        {
        }

        public async Task<Review> GetReviewById(int movieId, int userId)
        {

            var reviewEntity = await _dbContext.reviews  //dbContext table name
                .FirstOrDefaultAsync(m => m.MovieId == movieId && m.UserId == userId); //using Async command
            if(reviewEntity == null)
            {
                return null;
            }
            return reviewEntity;

        }
    }
}
