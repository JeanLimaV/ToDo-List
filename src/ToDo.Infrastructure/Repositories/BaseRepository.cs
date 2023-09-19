using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.PaginatedSearch;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Contracts;
using ToDo.Domain.Pagination;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.Context;
using System.Linq.Expressions;

namespace ToDo.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository where T : BaseEntity
    {
        protected BaseRepository(BaseDbContext context)
        {
            Context = context;
            -dbSet = context.Set<T>();
        }

        private readonly DbSet<T> _dbSet;
        protected readonly BaseDbContext Context;
        
        public IUnitOfWork UnitOfWork => Context;

        public async Task<IPaginatedResult<T>> Search(IPaginatedResult<T> filter)
        {
            var queryable = _dbSet.AsQueryable();

            filter.ApplyFilters(ref queryable);
            filter.ApplyOrdenation(ref queryable);

            var result = new PaginatedResult<T>(filter.Pages, await queryable.CountAsync(), filter.PageSize);

            var quantPages = (double)result.Pagination.TotalPages / filter.PageSize;
            result.Pagination.TotalPages = (int)Math.Ceiling(quantPages);

            var skip = (filter.Pages - 1) * filter.PageSize;
            result.Items = await queryable.Skip(skip).Take(filter.PageSize).ToListAsync();
            result.Pagination.TotalInPage = result.Items.Count;
            return result;
        }

        public async Task<T?> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate) => await _dbSet.AnyAsync(predicate);
    }
}