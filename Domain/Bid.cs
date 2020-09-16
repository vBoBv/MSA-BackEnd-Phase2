using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Bid
    {
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public Guid ItemId { get; set; }
        public virtual Item Item { get; set; }
        public DateTime Timestamp { get; set; }
        public int Price { get; set; }
    }
}
