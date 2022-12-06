using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Exceptions;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public static Address Empty = new(string.Empty);
        public string FullName { get; private set; }

        public Address(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new InvalidAddressException("fullname is empty");

            FullName = fullName;
        }

        protected override bool EqualCore(Address obj)
        {
            return GetType() == obj.GetType()
                   && obj.FullName == FullName;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(GetType(), FullName);
        }
    }
}
