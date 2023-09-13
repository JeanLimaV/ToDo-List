using System;
using ToDo-List.Domain.Entities;
using FluentValidation;

public class TaskValidator : AbstractValidator<Tasks>
{
	public class TaskValidator()
	{
		RuleFor(task => task.Name)
			.NotEmpty()
			.WithMessage("the name cannot be Empty!")
			.Length(3, 30)
			.WithMessage("The name cannot contain less than 3 or more than 30 characters.");
		
		RulerFor(task => task.Description)
			.MaximumLength(300)
			.WithMessage("The Description cannot be longer than 300 characters.");

		RuleFor(taks => task.DataExpiration)
			.GreaterThan(DateTime.Today)
			.WithMessage("the expiration date cannot be less than today's date.");
	}
}
