using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Contacts.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class ProductImageRepository : BaseRepository<ProductImage, int>, IProductImageRepository
    {
        public ProductImageRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
