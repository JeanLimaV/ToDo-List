namespace ToDo.Domain.Entities
{
    public class Tasks : BaseEntity
    {
        public long UserId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool Concluded { get; set; }
        public DateTime? DataExpiration { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public virtual Users User { get; set; } = null!;
    }

    
}