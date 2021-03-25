﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairShopProject.DataAccess.Concrete.EntityFramework;

namespace RepairShopProject.DataAccess.Migrations
{
    [DbContext(typeof(RepairShopContext))]
    partial class RepairShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RepairShopProject.Entities.Concrete.Appointment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("vehicleId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("vehicleId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            id = 1,
                            date = new DateTime(2021, 8, 27, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            vehicleId = 1
                        },
                        new
                        {
                            id = 2,
                            date = new DateTime(2021, 2, 21, 15, 30, 30, 0, DateTimeKind.Unspecified),
                            vehicleId = 2
                        });
                });

            modelBuilder.Entity("RepairShopProject.Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            id = 1,
                            IsRemoved = true,
                            email = "deneme@gmail.com",
                            fullName = "Ali",
                            phoneNumber = "0534 123 4567"
                        },
                        new
                        {
                            id = 2,
                            IsRemoved = true,
                            email = "deneme@gmail.com",
                            fullName = "Merve",
                            phoneNumber = "0534 123 4567"
                        },
                        new
                        {
                            id = 3,
                            IsRemoved = false,
                            email = "deneme@gmail.com",
                            fullName = "Aslı",
                            phoneNumber = "0534 123 4567"
                        },
                        new
                        {
                            id = 4,
                            IsRemoved = false,
                            email = "deneme@gmail.com",
                            fullName = "Kemal",
                            phoneNumber = "0534 123 4567"
                        },
                        new
                        {
                            id = 5,
                            IsRemoved = true,
                            email = "test@gmail.com",
                            fullName = "Ayşe",
                            phoneNumber = "0534 987 6543"
                        });
                });

            modelBuilder.Entity("RepairShopProject.Entities.Concrete.Vehicle", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<string>("licensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelYear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("customerId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            id = 1,
                            brand = "BMW",
                            customerId = 1,
                            licensePlate = "34 KLC 1234",
                            model = "i7",
                            modelYear = "2020"
                        },
                        new
                        {
                            id = 2,
                            brand = "Renault",
                            customerId = 2,
                            licensePlate = "42 MNP 1583",
                            model = "Clio",
                            modelYear = "2018"
                        },
                        new
                        {
                            id = 3,
                            brand = "Audi",
                            customerId = 3,
                            licensePlate = "34 JLG 5306",
                            model = "A3",
                            modelYear = "2017"
                        },
                        new
                        {
                            id = 4,
                            brand = "Audi",
                            customerId = 4,
                            licensePlate = "34 JLG 5306",
                            model = "A3",
                            modelYear = "2017"
                        },
                        new
                        {
                            id = 5,
                            brand = "Audi",
                            customerId = 5,
                            licensePlate = "34 JLG 5306",
                            model = "A3",
                            modelYear = "2017"
                        });
                });

            modelBuilder.Entity("RepairShopProject.Entities.Concrete.Appointment", b =>
                {
                    b.HasOne("RepairShopProject.Entities.Concrete.Vehicle", "Vehicles")
                        .WithMany()
                        .HasForeignKey("vehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RepairShopProject.Entities.Concrete.Vehicle", b =>
                {
                    b.HasOne("RepairShopProject.Entities.Concrete.Customer", "Customers")
                        .WithMany("Vehicles")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}