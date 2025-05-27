﻿using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)   
                .IsRequired(false)
               .HasMaxLength(500);

            builder.Property(x => x.Sku)
                .HasMaxLength(50);

            builder.Property(x => x.UnitPrice)
                .IsRequired(false)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CartItems)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.ProductImages)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId);
        }
    }
}
