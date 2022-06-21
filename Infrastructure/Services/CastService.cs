using ApplicationCore.Contract.Repository;
using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;
        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsModel> GetCastDetails(int id)
        {
            var castDetails =await _castRepository.GetById(id);
            var castDetailsModel = new CastDetailsModel
            {
                Id = castDetails.Id,
                Name = castDetails.Name,
                ProfilePath = castDetails.ProfilePath,
            };

            foreach (var item in castDetails.MovieCasts)
            {
                castDetailsModel.Cards.Add(new MovieCardModel { Id = item.MovieId, PosterUrl = item.Movie.PosterUrl });
            }

            return castDetailsModel;
        }
    }
}
