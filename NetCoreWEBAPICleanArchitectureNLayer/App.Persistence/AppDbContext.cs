using System.Reflection;
using CleanApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanApp.Persistence
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  

            base.OnModelCreating(modelBuilder);
        }
    }

}
