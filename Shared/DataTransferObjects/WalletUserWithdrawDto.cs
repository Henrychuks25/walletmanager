using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class WalletUserWithdrawDto
    {
        public Guid userId { get; init; }
        public string currency { get; init; }
        public decimal amount { get; init; }

        public DateTime UpdatedDate { get; set; }

    }
}
