namespace CustomerBasketManagement.Domain.Customers.Exceptions
{
    public class InvalidAddressException : BusinessException
    {
		public InvalidAddressException(string message)
			: base(message)
		{ }
	}
}
