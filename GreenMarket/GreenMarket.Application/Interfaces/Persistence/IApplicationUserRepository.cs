using GreenMarket.Application.Interfaces.Persistence;
using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace GreenMarket.Domain.Interfaces.Entities
{
    public interface IApplicationUserRepository
    {
        IQueryable<ApplicationUser> GetQueryableSet();

        Task<ApplicationUser?> GetByIdAsync(string id, Func<IQueryable<ApplicationUser>, IIncludableQueryable<ApplicationUser, object>>? include = null, CancellationToken cancellationToken = default);

        Task AddOrUpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task AddAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default);

        Task<ApplicationUser?> FirstOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);

        Task<ApplicationUser?> SingleOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);

        Task<List<ApplicationUser>> ToListAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default);
    }
}
