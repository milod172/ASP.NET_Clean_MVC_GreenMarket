using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Interfaces.Persistence
{
    public interface ICartItemRepository  : IBaseRepository<CartItem, int>
    {
    }
}
