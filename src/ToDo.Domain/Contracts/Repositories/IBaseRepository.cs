using System.Linq.Expressions;
using ToDo.Domain.Contracts.PaginatedSearch;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        public IUnitOfWork UnitOfWork { get; }
        Task<IPaginatedResult<T>> Search(IPaginatedResult<T> filtro);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}