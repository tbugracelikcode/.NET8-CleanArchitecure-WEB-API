﻿using System.Reflection;
using App.Repositories.Categories;
using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
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
