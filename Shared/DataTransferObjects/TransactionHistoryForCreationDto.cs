using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record TransactionHistoryForCreationDto
{
    [Key, Required]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [Required]
    public string TransactionType { get; set; }

    public decimal TransactionAmount { get; set; }


    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
