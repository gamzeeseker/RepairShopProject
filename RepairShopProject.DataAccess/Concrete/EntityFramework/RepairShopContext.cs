using Microsoft.EntityFrameworkCore;
using RepairShopProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepairShopProject.DataAccess.Concrete.EntityFramework
{
    public class RepairShopContext : DbContext
    {
        public RepairShopContext(DbContextOptions<RepairShopContext> options)
             : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle() { id = 1, customerId = 1, brand = "BMW", licensePlate = "34 KLC 1234", model = "i7", modelYear = "2020" },
                new Vehicle() { id = 2, customerId = 2, brand = "Renault", licensePlate = "42 MNP 1583", model = "Clio", modelYear = "2018" },
                new Vehicle() { id = 3, customerId = 3, brand = "Audi", licensePlate = "34 JLG 5306", model = "A3", modelYear = "2017" },
                new Vehicle() { id = 4, customerId = 4, brand = "Audi", licensePlate = "34 JLG 5306", model = "A3", modelYear = "2017" },
                new Vehicle() { id = 5, customerId = 5, brand = "Audi", licensePlate = "34 JLG 5306", model = "A3", modelYear = "2017" });

            modelBuilder.Entity<Customer>().HasData(
               new Customer() { id = 1, fullName = "Ali", email = "deneme@gmail.com", phoneNumber = "0534 123 4567", IsRemoved=true },
               new Customer() { id = 2, fullName = "Merve", email = "deneme@gmail.com", phoneNumber = "0534 123 4567", IsRemoved = true },
               new Customer() { id = 3, fullName = "Aslı", email = "deneme@gmail.com", phoneNumber = "0534 123 4567", IsRemoved = false },
               new Customer() { id = 4, fullName = "Kemal", email = "deneme@gmail.com", phoneNumber = "0534 123 4567", IsRemoved = false },
               new Customer() { id = 5, fullName = "Ayşe", email = "test@gmail.com", phoneNumber = "0534 987 6543", IsRemoved = true });

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment() { id = 1, vehicleId = 1, date = new DateTime(2021, 08, 27, 13, 00, 00) },  //DateTime(int year, int month, int day, int hour, int minute, int second)
               new Appointment() { id = 2, vehicleId = 2, date = new DateTime(2021, 02, 21, 15, 30, 30) });

            modelBuilder.Entity<Customer>().HasQueryFilter(u => !u.IsRemoved);
            base.OnModelCreating(modelBuilder);
        }
    }

}

