using FluentValidation;
using ToDo-List.Domain.Entities;

namespace ToDo.Domain.Entities
{
    public class UserValidator : AbstractValidator<Users>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("The Name cannot be Empty.")
                .Length(3, 30)
                .WithMessage("The Name cannot contain less than 3 or more than 30 characters.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("The Email cannot be Empty.")
                .Length(10, 80)
                .WithMessage("The Email cannot contain less than 10 or more than 80 characters.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("The Password cannot be Empty.")
                .Length(4, 25)
                .WithMessage("The Password cannot contain less than 4 or more than 25 characters.");
        }
    }
}