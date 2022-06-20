using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contract.Services
{
    public interface ICastService
    {
      
        //get movie details
        CastDetailsModel GetCastDetails(int id);
    }
}
