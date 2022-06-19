using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Review
    {
        public int MovieId { get; set; } //FK PK
        public int UserId { get; set; } //FK PK  
        
        public decimal Rating { get; set; } //PK
        
        public string ReviewText { get; set; } //PK

        //navigaation property FK
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
