using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Infrastructure.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.CartItems)
               .WithOne(x => x.Cart)
               .HasForeignKey(x => x.CartId)
               .OnDelete(DeleteBehavior.Cascade);   
        }
    }
}
