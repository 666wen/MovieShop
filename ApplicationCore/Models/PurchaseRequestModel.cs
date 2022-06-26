using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PurchaseRequestModel
    {
        public int MovieID { get; set; }
        public string Title { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime PurchaseDateTime { get; set; }
    }
}
