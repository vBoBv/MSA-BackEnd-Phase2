using Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
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

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Name = "Ponhvath",
                        UserName = "ponhvath",
                        Email = "ponhvath@email.com"
                    },
                    new AppUser
                    {
                        Name = "Vick",
                        UserName = "vick",
                        Email = "vick@email.com"
                    },
                    new AppUser
                    {
                        Name = "Bill",
                        UserName = "bill",
                        Email = "bill@email.com"
                    }
                };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "WhatIsMyPass123");
                }
            }
        }
    }
}