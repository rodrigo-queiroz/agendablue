using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ScheduleBlue.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScheduleBlue.Infrastructure.Persistence
{
    public class OrderIdValueGenerator : ValueGenerator<int>
    {
        private int _current;
        public override bool GeneratesTemporaryValues => false;
        public override int Next(EntityEntry entry)
            => Interlocked.Increment(ref _current);
    }
    public class ScheduleBlueDbContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ScheduleBlue");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>(order =>
            {
                order.Property(p => p.Id).HasValueGenerator<OrderIdValueGenerator>();
            });
        }
    }
}
