using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.Property(x => x.VariantName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.VariantSku)
               .HasMaxLength(50);

            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductVariants)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.OrderItems)
                .WithOne(x => x.ProductVariant)
                .HasForeignKey(x => x.ProductVariantId);

            builder.HasMany(x => x.CartItems)
               .WithOne(x => x.ProductVariant)
               .HasForeignKey(x => x.ProductVariantId);

        }
    }
}
