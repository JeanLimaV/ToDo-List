namespace ToDo.Domain.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime Created { get; set; }

        public virtual List<Task> TasksList { get; set; } = new();
    }
}