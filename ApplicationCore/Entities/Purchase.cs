using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Purchase
    {
        public int Id { get; set; } //PK
        public int UserId { get; set; } //FK 
        public int MovieId { get; set; } //FK 

        public Guid PurchaseNumber { get; set; } //globle unique id

        public decimal TotalPrice { get; set; } 

        public DateTime PurchaseDateTime { get; set; }

        //navigaation property FK
        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
