using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieGenre
    {
        public int MovieId { get; set; } //composed pk
        public int GenreId { get; set; } //composed pk

        // Navigation properties
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }
    }
}

