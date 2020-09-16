using System;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            //Define Primary Keys for Bid Model
            builder.Entity<Bid>(x => x.HasKey(b =>
                new { b.AppUserId, b.ItemId }));

            //Define relationships
            builder.Entity<Bid>()
                .HasOne(u => u.AppUser)
                .WithMany(i => i.Bids)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<Bid>()
                .HasOne(i => i.Item)
                .WithMany(u => u.Bids)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
