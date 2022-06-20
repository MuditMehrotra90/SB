using System;
using SB.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace SB.EntityFramework
{
	public class ApplicationDBContext : DbContext
	{
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Entity_Item>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,4)");

            builder.Entity<Entity_Category>().HasData(new Entity_Category { Id = 1, Name = "Tables" },
                new Entity_Category { Id = 2, Name = "Chairs" },
                new Entity_Category { Id = 3, Name = "Wardroabs" },
                new Entity_Category { Id = 4, Name = "Beds" });
        }
        public DbSet<Entity_Category> Categories { get; set; }
        public DbSet<Entity_Item> Items { get; set; }
    }
}
