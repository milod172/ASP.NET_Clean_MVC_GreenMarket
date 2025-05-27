using GreenMarket.Application.Interfaces.Persistence;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Infrastructure.Persistence.Repositories;

namespace GreenMarket.Infrastructure.Repositories
{
    public class CartItemRepository : BaseRepository<CartItem, int>, ICartItemRepository
    {
        public CartItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
