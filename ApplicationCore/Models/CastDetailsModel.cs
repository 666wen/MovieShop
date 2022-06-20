using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastDetailsModel
    {
        public int Id { get; set; }  //from cast entity

        public string Name { get; set; }

        public string ProfilePath { get; set; }

        public List<MovieCardModel> Cards { get; set; }

        public CastDetailsModel()
        {
            Cards=new List<MovieCardModel>();
        }
    }
}
