using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record TransactionHistoryDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string username { get; set; }
    public string TransactionType { get; set; }

    public decimal TransactionAmount { get; set; }


    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
