using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.Repositories
{
    public interface ITasksRepository : IBaseRepository<Tasks>
    {
        void Create(Tasks tasks);
        void Update(Tasks tasks);
        void Remove(Tasks tasks);
        Task<Tasks?> GetById(long id);
    }
}