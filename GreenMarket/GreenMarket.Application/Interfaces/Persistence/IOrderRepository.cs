using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Interfaces.Persistence
{
    public interface IOrderRepository : IBaseRepository<Order, int>
    {
    }
}
