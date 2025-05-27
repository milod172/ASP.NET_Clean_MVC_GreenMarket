using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {         
            builder.Property(x => x.Quantity)
                .IsRequired();              

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.ProductVariant)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.ProductVariantId);
        }
    }
}
