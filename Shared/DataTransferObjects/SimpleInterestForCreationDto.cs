using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record SimpleInterestForCreationDto
{
   

    public Guid UserId { get; set; }
    public Guid WalletId { get; set; }

    public string currency { get; set; }

    //public decimal TransactionAmount { get; set; }


    //public DateTime CreatedDate { get; set; }
    //public DateTime UpdatedDate { get; set; }
}
