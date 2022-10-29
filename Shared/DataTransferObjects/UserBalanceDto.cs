using Entities.Models;

namespace Shared.DataTransferObjects;

public record UserBalanceDto
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public string NGNWallet { get; set; }
    public string USDWallet { get; set; }
    public decimal Amount { get; set; }

    //public virtual ICollection<Wallet> Wallets { get; set; } = new List<Wallet>();


}