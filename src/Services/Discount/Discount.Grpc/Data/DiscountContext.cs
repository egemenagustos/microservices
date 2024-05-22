﻿using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .HasData(
                new Coupon()
                {
                    Id = 1,
                    ProductName = "Iphone X",
                    Amount = 100,
                    Description = "Iphone Discount"
                },
                new Coupon()
                {
                    Id = 2,
                    ProductName = "Samsung 10",
                    Amount = 102,
                    Description = "Samsung Discount"
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
