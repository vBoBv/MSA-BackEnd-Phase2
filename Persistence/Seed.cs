using Domain;
using System.Collections.Generic;
using System.Linq;

namespace Persistence
{
  public class Seed
  {
    public static void SeedData(DataContext context)
    {
      if (!context.Items.Any())
      {
        var items = new List<Item>
        {
            new Item
            {
                Name = "Mars",
                Description = "Planet 1",
                Possession = "Bob"
            },
            new Item
            {
                Name = "Uranus",
                Description = "Planet 3",
                Possession = "Vicky"
            },
            new Item
            {
                Name = "Venus",
                Description = "Planet 4",
                Possession = "Ben"
            },
        };

        context.Items.AddRange(items);
        context.SaveChanges();
      }
    }
  }
}