using FluentValidation.Results;

namespace ToDo.Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public virtual bool Validate(out ValidationResult validationResult)
        {
            validationResult = new ValidationResult();
            return validationResult.IsValid;
        }
    }
}