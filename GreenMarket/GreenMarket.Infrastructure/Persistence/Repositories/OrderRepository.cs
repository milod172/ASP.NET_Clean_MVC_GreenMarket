using GreenMarket.Infrastructure.Persistence;
using GreenMarket.Domain.Entities;
using GreenMarket.Infrastructure.Persistence.Repositories;
using GreenMarket.Application.Contacts.Persistence;

namespace GreenMarket.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order, int>, IOrderRepository
    {
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
