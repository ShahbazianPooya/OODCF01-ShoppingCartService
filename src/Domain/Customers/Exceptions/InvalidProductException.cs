namespace CustomerBasketManagement.Domain.Customers.Exceptions
{
    public class InvalidProductException : BusinessException
    {
		public InvalidProductException(string message)
			: base(message)
		{ }
	}
}
