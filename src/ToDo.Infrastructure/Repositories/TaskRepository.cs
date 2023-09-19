using ToDo.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Enrtities;
using ToDo.Infrastructure.Context;

namespace ToDo.Infrastructure.Repositories;
{
    public class TaskRepository : BaseRepository<Tasks>, ItasksRepository
    {
        public TaskRepository(BaseDbContext context) : base(context){}

        public void Create(Tasks tasks) => Context.Tasks.Add(tasks);
        public void Update(Tasks tasks) => Context.Tasks.Update(tasks);
        public void Remove(Tasks tasks) => Context.Tasks.Remove(tasks);

        public async Task<Tasks?> GetById(int id)
        {
            return await Context.Tasks
                .AsNoTracking()
                .Where(tasks => tasks.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}