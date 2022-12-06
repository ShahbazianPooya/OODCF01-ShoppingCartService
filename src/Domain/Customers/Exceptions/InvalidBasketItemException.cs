namespace CustomerBasketManagement.Domain.Customers.Exceptions
{
    public class InvalidBasketItemException : BusinessException
    {
		public InvalidBasketItemException(string message)
			: base(message)
		{ }
	}
}
