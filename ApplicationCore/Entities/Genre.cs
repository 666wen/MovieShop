using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    //[Table("Genre")]
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(64)] //change db in data annotation way
        public string Name { get; set; }

        

        public ICollection<MovieGenre> MoviesOfGenre { get; set; }

    }
}
