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
        public int ID { get; set; }
        public string Title { get; set; }

        public string Actors { get; set; }
        public int Runtime { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
