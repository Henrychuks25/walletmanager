using Application.Commands;
using FluentValidation;
using FluentValidation.Results;
using Repository;

namespace Application.Validators;

public sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	private readonly RepositoryContext _repositoryContext;

	public CreateUserCommandValidator(RepositoryContext repositoryContext)
	{
		RuleFor(c => c.User.Email).NotNull().NotEmpty().EmailAddress().Must(IsEmailUnique);

		RuleFor(c => c.User.Password).NotEmpty().MaximumLength(60);
		_repositoryContext = repositoryContext;
	}

	public override ValidationResult Validate(ValidationContext<CreateUserCommand> context)
	{
		return context.InstanceToValidate.User is null
			? new ValidationResult(new[] { new ValidationFailure("UserForCreationDto",
				"UserForCreationDto object is null") })
			: base.Validate(context);
	}

    public bool IsEmailUnique(string email)
    {
	var result = _repositoryContext.User.Where(u => u.Email == email).FirstOrDefault(); 
		if (result == null)
		{
			return true;
		}
		
        return false;
    }

}
