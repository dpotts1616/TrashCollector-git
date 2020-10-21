using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "24cc24db-7b4a-471b-b620-3e50742c7f19",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
                );
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Id = "30b01b69-42e6-4020-af89-c470ec2167ef",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
                );
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ZipCode> ZipCodes { get; set; }

        public DbSet<Day> Days { get; set; }
    }
}
