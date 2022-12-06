namespace CustomerBasketManagement.Domain.Customers.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        { }
    }
}
