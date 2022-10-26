namespace Shared.DataTransferObjects;

public record UserForCreationDto
{ 
     public Guid Id { get; init; } = Guid.NewGuid();
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }

}