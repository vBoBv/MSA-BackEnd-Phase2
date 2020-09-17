using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Discussions
{
    public class DiscussionDto
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreateAt { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        
    }
}
