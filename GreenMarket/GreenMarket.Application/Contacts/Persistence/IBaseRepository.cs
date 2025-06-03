using System.Linq.Expressions;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Products.Queries;
using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace GreenMarket.Application.Contacts.Persistence
{
    public interface IBaseRepository<T, TKey> where T : BaseEntity<TKey>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T?> GetByIdAsync(TKey id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);

        Task<T?> GetByAttributeAsync(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);

        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default);
        Task<PaginationList<T>> GetPaginated(
            PaginatedQuery query,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IQueryable<T>>? include = null,
            CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);

        Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);

        Task<int> CountAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default);
    }
}
