using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieDetialsModel
    {
        //many many properties depends on movie detials page view 
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        public string? ImdbUrl { get; set; }
        public string? TmdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CreatedBy { get; set; }
        public decimal Ave_rating { get; set; }


        //add in list of other models. one movie -> many genre, many cast, many trailer, Review.
        public List<GenreModel> Genres { get; set; }
        public List<CastModel> Casts { get; set; }

        public List<TrailerModel> Trailers { get; set; }

        public List<ReviewModel> Reviews { get; set; }

        //constructor Initialize
        public MovieDetialsModel()
        {
            Genres=new List<GenreModel>();
            Casts=new List<CastModel>();
            Trailers=new List<TrailerModel>();
            Reviews=new List<ReviewModel>();

        }
    }
}
