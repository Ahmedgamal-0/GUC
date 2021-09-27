using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUC.Entities
{
    public class GucDBContext:DbContext
    {
        public GucDBContext(DbContextOptions<GucDBContext> options) : base(options)
        {
            Database.Migrate();

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Sales> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Sales>().ToTable("Sales");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<Orders>().ToTable("Orders");
        }
    }
}
