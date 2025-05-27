using GreenMarket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GreenMarket.Domain.Entities;
using GreenMarket.Domain.Interfaces.Entities;
using Microsoft.EntityFrameworkCore.Query;
using GreenMarket.Infrastructure.Common;

namespace GreenMarket.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDateTimeProvider _dateTimeProvider;

        protected DbSet<ApplicationUser> DbSet => _dbContext.Set<ApplicationUser>();

 

        public ApplicationUserRepository(AppDbContext dbContext, IDateTimeProvider dateTimeProvider)
        {
            _dbContext = dbContext;
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<ApplicationUser?> GetByIdAsync(string id,Func<IQueryable<ApplicationUser>, IIncludableQueryable<ApplicationUser, object>>? include = null,CancellationToken cancellationToken = default)
        {
            IQueryable<ApplicationUser> query = _dbContext.Customers;

            if (include != null)
            {
                query = include(query);
            }

            return await query.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }


        public async Task AddOrUpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                await AddAsync(entity, cancellationToken);
            }
            else
            {
                await UpdateAsync(entity, cancellationToken);
            }
        }

        public async Task AddAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedDate = _dateTimeProvider.Now;
            await DbSet.AddAsync(entity, cancellationToken);
        }

        public virtual Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<ApplicationUser> GetQueryableSet()
        {
            return DbSet.AsQueryable();
        }

        public async Task<ApplicationUser?> FirstOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ApplicationUser?> SingleOrDefaultAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ApplicationUser>> ToListAsync(IQueryable<ApplicationUser> query, CancellationToken cancellationToken = default)
        {
            return await query.ToListAsync(cancellationToken);
        } 
    }

}
