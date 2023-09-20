using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ToDo.Core.Authorization;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Infrastructure.Context;
using ToDo.Infrastructure.Repositories;

namespace ToDo.Infrastructure
{
    public static class DependencyInjectionInfra
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthenticatedUser>(sp =>
            {
                var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();
                return httpContextAccessor.AuthenticatedUser()
                    ? new IAuthenticatedUser(httpContextAccessor)
                    : new AuthenticatedUser();
            });

            services.AddDbContext<BaseDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var serverVersion = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, serverVersion);
                options.EnableSensitiveDataLogging();
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITasksRepository, TaskRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

        public static void UseMigrations(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
            db.Database.Migrate();
        }
    }
}