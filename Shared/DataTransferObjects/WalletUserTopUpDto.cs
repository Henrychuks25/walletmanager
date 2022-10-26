using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class WalletUserTopUpDto
    {
        public Guid userId { get; init; }
        public string currency { get; init; }
        public decimal amount { get; init; }
    }
}
