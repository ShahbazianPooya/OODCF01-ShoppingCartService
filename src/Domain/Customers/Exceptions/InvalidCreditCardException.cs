namespace CustomerBasketManagement.Domain.Customers.Exceptions
{
    public class InvalidCreditCardException : BusinessException
    {
		public InvalidCreditCardException(string message)
			: base(message)
		{ }
	}
}
