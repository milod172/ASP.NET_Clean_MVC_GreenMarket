using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasOne(x => x.Cart)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                 .WithMany(x => x.CartItems)
                 .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.ProductVariant)
                .WithMany(x => x.CartItems)
                .HasForeignKey(x => x.ProductVariantId);
        }
    }
}
