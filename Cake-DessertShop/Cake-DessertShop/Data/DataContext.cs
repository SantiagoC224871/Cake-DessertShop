using CakeDessertShop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CakeDessertShop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>().HasIndex(s => s.Name).IsUnique();
        }
    }
}
