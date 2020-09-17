using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Discussion
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public virtual AppUser Author { get; set; }
        public virtual Item Item {get; set;}
        public DateTime CreateAt { get; set; }
    }
}
