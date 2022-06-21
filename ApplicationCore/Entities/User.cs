using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string? FirstName { get; set; }
        [MaxLength(128)]
        public string? LastName { get; set; }


        public DateTime? DateOfBirth { get; set; }
        [MaxLength(256)]
        public string? Email { get; set; }
        [MaxLength(1024)]
        public string? HashedPassword { get; set; }
        [MaxLength(1024)]
        public string? Salt { get; set; }
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }

        public Boolean? TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDate { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public Boolean? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }
        

        //navigation
        public ICollection<Review> Review { get; set; }
        public ICollection<Purchase> Purchase { get; set; }
        public ICollection<Favorite> Favorite { get; set; }
        public ICollection<UserRole> userRoles { get; set; }



    }
}
