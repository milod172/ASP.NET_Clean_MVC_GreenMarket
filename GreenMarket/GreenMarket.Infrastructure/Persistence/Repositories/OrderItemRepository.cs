using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Interfaces.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem, int>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
