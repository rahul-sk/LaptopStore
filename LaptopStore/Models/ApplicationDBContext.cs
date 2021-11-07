using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaptopStore.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Orders> Orders { get; set; }

        //public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        //{

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>().HasOne(b => b.Laptops)
                .WithMany(ba => ba.Orders)
                .HasForeignKey(bi => bi.LaptopId);

            modelBuilder.Entity<Orders>().HasOne(b => b.Customers)
                .WithMany(ba => ba.Orders)
                .HasForeignKey(bi => bi.CustomerId);


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DGQ22P73;Database=LaptopStoreRepo;Integrated Security=true;");
        }
    }
}
