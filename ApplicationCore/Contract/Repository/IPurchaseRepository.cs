﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Repository
{
    public interface IPurchaseRepository: IRepository<Purchase>
    {
        Task<List<Movie>> GetMoviesByUserId(int userId);
    }
    
}
