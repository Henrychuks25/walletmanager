namespace Shared.DataTransferObjects;

public record UserBalanceDto
{ 
     public Guid Id { get; init; } 
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }

    public string? Wallet { get; init; }

}