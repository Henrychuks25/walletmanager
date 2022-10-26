using Entities.Models;

namespace Entities.Exceptions;

public sealed class InsufficientFundException : Exception
{
	public InsufficientFundException(string message)
        : base("Dear customer, you have insufficient fund.")
    { }
}
