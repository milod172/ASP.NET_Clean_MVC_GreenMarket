using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Contacts.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class ProductVariantRepository : BaseRepository<ProductVariant, int>, IProductVariantRepository
    {
        public ProductVariantRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
