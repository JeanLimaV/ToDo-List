using System;
using ToDo.Domain.Entities;
using FluentValidation;

namespace ToDo.Domain.Validators
{
	public class TaskValidator : AbstractValidator<Tasks>
	{
		public TaskValidator()
		{
			RuleFor(task => task.Name)
				.NotEmpty()
				.WithMessage("the name cannot be Empty!")
				.Length(3, 30)
				.WithMessage("The name cannot contain less than 3 or more than 30 characters.");
		
			RuleFor(task => task.Description)
				.MaximumLength(300)
				.WithMessage("The Description cannot be longer than 300 characters.");

			RuleFor(task => task.DataExpiration)
				.GreaterThan(DateTime.Today)
				.WithMessage("the expiration date cannot be less than today's date.");
		}
	}
}