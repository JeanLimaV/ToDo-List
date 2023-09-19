using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infrastructure.Context;

namespace ToDo.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<Users>, IUsersRepository
    {
        public UsersRepository(BaseDbContext context) : base(context){}

        public void Create(Users users)
        {
            Context.Users.Add(users);
        }
        public void Update(Users users)
        {
            Context.Users.Update(users);
        }

        public void Remove(Users users)
        {
            Context.Users.Remove(users);
        }

        public async Task<Users?> GetById(int id)
        {
            return await Context.Users
                .AsNoTracking()
                .where(users => users.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}