using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.TotalAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.OwnsOne(o => o.ShippingAddress);

            builder.Property(x => x.PaymentMethod)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.PaymentStatus)
                 .IsRequired()
                 .HasConversion<string>();

            builder.Property(x => x.OrderStatus)
                .IsRequired()
                .HasConversion<string>();

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
