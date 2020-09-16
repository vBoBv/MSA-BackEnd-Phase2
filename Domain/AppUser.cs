using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}