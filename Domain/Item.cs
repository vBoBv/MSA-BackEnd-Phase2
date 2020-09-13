using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public class Item
  {
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public string Possession { get; set; }
  }
}