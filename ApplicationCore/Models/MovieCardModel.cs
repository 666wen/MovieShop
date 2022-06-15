using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class MovieCardModel   //based on view needed properties.
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
    }
}
