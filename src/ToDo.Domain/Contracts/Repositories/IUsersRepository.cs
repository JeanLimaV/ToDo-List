using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories
{
    public interface IUsersRepository : IBaseRepository<Users>
    {
        void Create(Users users);
        void Update(Users users);
        void Remove(Users users);
        Task<Users?> GetById(long id);
    }
}