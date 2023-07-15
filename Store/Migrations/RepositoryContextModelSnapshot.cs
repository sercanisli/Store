﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositories.Concrete.Context;

#nullable disable

namespace Store.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Book"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Electronic"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Price = 17000m,
                            ProductName = "Computer"
                        },
                        new
                        {
                            Id = 2,
                            Price = 1000m,
                            ProductName = "Keyboard"
                        },
                        new
                        {
                            Id = 3,
                            Price = 500m,
                            ProductName = "Mouse"
                        },
                        new
                        {
                            Id = 4,
                            Price = 7000m,
                            ProductName = "Monitor"
                        },
                        new
                        {
                            Id = 5,
                            Price = 1500m,
                            ProductName = "Deck"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
