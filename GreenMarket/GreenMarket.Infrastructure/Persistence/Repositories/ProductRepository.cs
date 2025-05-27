using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Interfaces.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext): base(dbContext)
        {
        }
    }
}
