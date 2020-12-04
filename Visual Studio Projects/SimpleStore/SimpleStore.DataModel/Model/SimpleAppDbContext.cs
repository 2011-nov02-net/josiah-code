using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SimpleStore.DataModel.Model;

namespace SimpleStore.DataModel
{
    public class SimpleAppDbContext : DbContext

    {
        public SimpleAppDbContext(DbContextOptions<SimpleAppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasCheckConstraint(name: "CK_Location_Stock_Nonnegative", sql: "[Stock] >= 0");

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Location)
                    .WithMany(l => l.Orders)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
        }
    }
}
