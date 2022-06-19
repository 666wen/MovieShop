using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class CastModel
    {
        public int Id { get; set; }  //from cast entity

        public string Name { get; set; }

        public string ProfilePath { get; set; }
        public string Character { get; set; } //from movieCast entity
    }
}
