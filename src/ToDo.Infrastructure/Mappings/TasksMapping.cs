using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.Infrastructure.Mappings
{
    public class TasksMapping : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.ToTable("Tasks");
            
            builder.HasKey(tasks => tasks.Id);

            builder.Property(tasks => tasks.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(tasks => tasks.Description)
                .HasMaxLength(200);

            builder.Property(tasks => tasks.Concluded)
                .IsRequired();

            builder.Property(tasks => tasks.DataExpiration);

            builder.Property(tasks => tasks.Created)
                .IsRequired();

            builder.HasOne(tasks => tasks.User)
                .WithMany(task => task.TaskList)
                .HasForeignKey(task => task.UserId)
                .HasPrincipalKey(tasks => tasks.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}