using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class WalletUserTransferDto
    {
        public Guid userId { get; init; }
        public string fromCurrency { get; init; }
        public string toCurrency { get; init; }
        public decimal amount { get; init; }

        public ICurrencyHelper currencyHelper { get; init; }

        public enum ICurrencyHelper
        {
            USD,
            NGN
        }
    }
}
