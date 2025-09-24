using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Inventory_Managment_System_Project.Models;

namespace Inventory_Managment_System_Project.Models
{
    public class MyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder.UseSqlServer("Server=MAHMOUD\\SQLEXPRESS;Database=InventoryManagment;Trusted_Connection=True; TrustServerCertificate=True;");


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // optionsBuilder.Entity<Trainingcourses>()
            //  .Property(prop => p.M).HasColumnName("Maximum");

            modelbuilder.HasDefaultSchema("ER");

            //modelbuilder.Entity<Author>().HasIndex(p => p.FirstName);
            modelbuilder.Entity<Admin>().Property(p => p.FullName).HasComputedColumnSql("[FirstName] + ' '+ [LastName]");
            //modelbuilder.Entity<Book>().Property(b => b.Title).HasDefaultValue("None");
        }

        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public MyContext()
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SignUp> SignUps { get; set; }
        //public DbSet<LogIn> LogIns { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Report> Reports { get; set; }



    }

}
