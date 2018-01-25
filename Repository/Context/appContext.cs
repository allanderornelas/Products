using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class appContext : DbContext
    {
        public appContext(DbContextOptions<appContext> options) : base(options) {}

        public DbSet<Product> Product { get; set; }
        public DbSet<ProductType> ProductType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType);
        }

    }
}
