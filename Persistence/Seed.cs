using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        Name = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        Id = "b",
                        Name = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        Id = "c",
                        Name = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Items.Any())
            {
                var items = new List<Item>
                {
                    new Item
                    {
                        Name = "Earth",
                        Description = "Planet1",
                        Possession = "Bob",
                        Bids = new List<Bid>
                        {
                            new Bid
                            {
                                AppUserId = "a",
                                Price = 200,
                                Timestamp = DateTime.Now
                            }
                        }
                    },
                    new Item
                    {
                        Name = "Pluto",
                        Description = "Planet2",
                        Possession = "Bill",
                        Bids = new List<Bid>
                        {
                            new Bid
                            {
                                AppUserId = "a",
                                Price = 200,
                                Timestamp = DateTime.Now
                            },
                            new Bid
                            {
                                AppUserId = "c",
                                Price = 200,
                                Timestamp = DateTime.Now
                            }
                        }
                    },
                };

                await context.Items.AddRangeAsync(items);
                await context.SaveChangesAsync();
            }
        }
    }
}