using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record SimpleInterestDto
{
    public Guid UserId { get; set; }
    public Guid WalletId { get; set; }

    public string Currency { get; set; }

    public decimal TransactionAmount { get; set; }
}
