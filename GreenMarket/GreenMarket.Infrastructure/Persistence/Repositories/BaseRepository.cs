using System.Linq.Expressions;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace GreenMarket.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey>, IUnitOfWork
    where T : BaseEntity<TKey>

    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;

            return await query.ToListAsync(cancellationToken);
        }

        public virtual async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public Task<PaginationList<T>> GetPaginated(
         PaginatedQuery query,
         Expression<Func<T, bool>>? filter = null,
         Func<IQueryable<T>, IQueryable<T>>? include = null,
         CancellationToken cancellationToken = default)
        {

            if (query == null) throw new ArgumentNullException(nameof(query));
            IQueryable<T> queryable = dbSet.AsQueryable();

            // Áp dụng filter nếu có
            if (filter != null)
            {
                queryable = queryable.Where(filter);
            }

            // Áp dụng include nếu có
            if (include != null)
            {
                queryable = include(queryable);
            }

            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var sortParts = query.SortBy.ToLower().Split(" ");
                var property = sortParts[0].Trim(); // Chỉ lấy tên cột

                var validProperties = typeof(T).GetProperties().Select(p => p.Name).ToList();
                var actualProperty = validProperties.SingleOrDefault(p => p.Equals(property, StringComparison.OrdinalIgnoreCase));

                if (actualProperty != null)
                {
                    if (sortParts.Length > 1 && sortParts[1] == "desc") // Kiểm tra nếu có "desc"
                    {
                        queryable = queryable.OrderByDescending(t => EF.Property<object>(t, actualProperty));
                    }
                    else
                    {
                        queryable = queryable.OrderBy(t => EF.Property<object>(t, actualProperty));
                    }
                }
                else
                {
                    throw new ArgumentException($"Property '{property}' does not exist in '{typeof(T).Name}'.");
                }
            }


            return Task.FromResult(PaginationList<T>.Create(queryable, query.PageSize, query.PageNumber));
        }


        public virtual async Task<T?> GetByAttributeAsync(Expression<Func<T, bool>>? filter, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public virtual async Task<T?> GetByIdAsync(TKey id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = dbSet;


            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(c => c.Id!.Equals(id), cancellationToken);
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        public virtual Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            dbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task DeleteByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            T? entityToDelete = await GetByIdAsync(id, null, cancellationToken);
            if (entityToDelete != null)
            {
                await DeleteAsync(entityToDelete, cancellationToken);
            }
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await dbSet.AnyAsync(filter, cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = default)
        {
            if (filter != null)
            {
                return await dbSet.CountAsync(filter, cancellationToken);
            }
            return await dbSet.CountAsync(cancellationToken);
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}
