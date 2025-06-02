using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Infrastructure.Persistence.Repositories;

namespace GreenMarket.Infrastructure.Repositories
{
    public class CartRepository : BaseRepository<Cart, int>, ICartRepository
    {
        public CartRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
