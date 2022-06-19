using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCast
    {
        public int CastId { get; set; } //foreign key [cast][ID]
        public int MovieId { get; set; } //foreign key [Movie][ID]

        [MaxLength(450)]
        public string Character { get; set; }

        // Navigation property FK
        public Movie Movie { get; set; }
        public Cast Cast { get; set; }
    }
}
