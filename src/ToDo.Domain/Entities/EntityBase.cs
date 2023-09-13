using FluentValidation.Results;

namespace ToDo.Domain.Entities
{
    public class EntityBase<T>
    {
        public T Id { get; set; }

        public virtual bool Validate(out ValidationResult validationResult)
        {
            var validator = new TaskValidator();
            validationResult = validator.Validate(this);
            return validationResult.IsValid;
        }
    }
}