using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Crew
    {
        public int Id { get; set; }  //PK

        [MaxLength(128)]
        public string Name { get; set; }

        public string Gender { get; set; }
        public string TmdbUrl { get; set; }

        [MaxLength(2084)]
        public string ProfliePath { get; set; }

        //public ICollection<MovieCrew> MovieCrews { get; set; }
    }
}
