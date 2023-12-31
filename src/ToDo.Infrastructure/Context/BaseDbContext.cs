using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Context
{
    public class BaseDbContext : DbContext, IUnitOfWork
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options){}
        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Tasks> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci")
                .UseGuidCollation(string.Empty);
            modelBuilder.Ignore<ValidationResult>();
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit() => await SaveChangesAsync() > 0;
    }
}