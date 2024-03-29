﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IReviewRepository:IRepository<Review>
    {
        Task<Review> GetReviewById(int movieId, int userId);
    }
}
