using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Mappings
{
    public class UsersMapping : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(users => users.Id);

            builder.Property(users => users.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(users => users.Email)
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(users => users.Password)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(tasks => tasks.Created)
                .IsRequired();
        }
    }
}