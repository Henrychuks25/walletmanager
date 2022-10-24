namespace Shared.DataTransferObjects;

public record UserForCreationDto(string FirstName, string LastName, string Email, string Password);