using Application.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(c => c.User.Email).NotNull().NotEmpty().EmailAddress();

		RuleFor(c => c.User.Password).NotEmpty().MaximumLength(60);
	}

	public override ValidationResult Validate(ValidationContext<CreateUserCommand> context)
	{
		return context.InstanceToValidate.User is null
			? new ValidationResult(new[] { new ValidationFailure("UserForCreationDto",
				"UserForCreationDto object is null") })
			: base.Validate(context);
	}
}
