using Application.Discussions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Items
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Possession { get; set; }
        public ICollection<BidDto> Bids { get; set; }
        public ICollection<DiscussionDto> Discussions { get; set; }
    }
}
