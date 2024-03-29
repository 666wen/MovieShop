﻿using ApplicationCore.Contract.Repository;
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
    public class PurchaseRepository: Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContaxt) : base(dbContaxt)
        {
        }

        public async Task<List<Movie>> GetMoviesByUserId(int userId)
        {
            //get all movieId buy by this user
            var moviesForUser =await _dbContext.purchases
                .Where(x => x.UserId == userId)
                .Include(x => x.Movie)
                .Select(x => new Movie { Id = x.MovieId, PosterUrl = x.Movie.PosterUrl, Title = x.Movie.Title })
                .ToListAsync();

            return moviesForUser;

        }


    }
}
