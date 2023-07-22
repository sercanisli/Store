﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { Id = 1, CategoryId = 2, ImageUrl = "/images/1.jpg", ProductName = "Computer", Price = 17_000, ShowCase = false},
                new Product() { Id = 2, CategoryId = 2, ImageUrl = "/images/2.jpg", ProductName = "Keyboard", Price = 1000, ShowCase = false },
                new Product() { Id = 3, CategoryId = 2, ImageUrl = "/images/3.jpg", ProductName = "Mouse", Price = 500, ShowCase = false },
                new Product() { Id = 4, CategoryId = 2, ImageUrl = "/images/4.jpg", ProductName = "Monitor", Price = 7_000, ShowCase = false },
                new Product() { Id = 5, CategoryId = 2, ImageUrl = "/images/5.jpg", ProductName = "Deck", Price = 1_500, ShowCase = false },
                new Product() { Id = 6, CategoryId = 1, ImageUrl = "/images/6.jpg", ProductName = "History", Price = 30, ShowCase = false },
                new Product() { Id = 7, CategoryId = 1, ImageUrl = "/images/7.jpg", ProductName = "Hamlet", Price = 15, ShowCase = false },
                new Product() { Id = 8, CategoryId = 1, ImageUrl = "/images/8.jpg", ProductName = "Sunglasses", Price = 150, ShowCase = true },
                new Product() { Id = 9, CategoryId = 2, ImageUrl = "/images/9.jpg", ProductName = "Joystick", Price = 75, ShowCase = true },
                new Product() { Id = 10, CategoryId = 1, ImageUrl = "/images/10.jpg", ProductName = "Toy Car", Price = 5, ShowCase = true }

            );
        }
    }
}
