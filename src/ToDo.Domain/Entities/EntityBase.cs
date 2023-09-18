using FluentValidation.Results;
using ToDo.Domain.Validators;

namespace ToDo.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }

        public virtual bool Validate(out ValidationResult validationResult)
        {
            validationResult = new ValidationResult();
            return validationResult.IsValid;
        }
    }
}