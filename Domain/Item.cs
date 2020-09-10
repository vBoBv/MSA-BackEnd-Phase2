using System;

namespace Domain
{
  public class Item
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Possession { get; set; }
  }
}