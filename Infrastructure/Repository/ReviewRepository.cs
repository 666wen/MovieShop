using ApplicationCore.Contract.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReviewRepository:Repository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContaxt) : base(dbContaxt)
        {
        }

    }
}
