using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Interfaces.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class CartRepository : BaseRepository<Cart, int>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
