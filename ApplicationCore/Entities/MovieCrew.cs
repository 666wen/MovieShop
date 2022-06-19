using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class MovieCrew
    {
        public int MovieId { get; set; } //FK PK
        public int CrewId { get; set; } //FK PK  
        [MaxLength(128)]
        public string Department { get; set; } //PK
        [MaxLength(128)]
        public string Job { get; set; } //PK

        //navigaation property FK
        public Movie Movie { get; set; }
        public Crew Crew { get; set; }

    }
}
