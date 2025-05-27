using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Interfaces.Persistence
{
    public interface IProductRepository : IBaseRepository<Product, int>
    {
    }
}
