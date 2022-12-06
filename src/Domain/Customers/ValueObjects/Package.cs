using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Enums;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class Package : ValueObject<Package>
    {
        private readonly PackageType _packageType;
        public decimal Price { get; private set; }

        public Package(PackageType packageType)
        {
            _packageType = packageType;
            Price = _packageType == PackageType.Normal ? 0 : 1000;
        }

        protected override bool EqualCore(Package obj)
        {
            return GetType() == obj.GetType() && Price == obj.Price;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(GetType(), Price);
        }
    }
}
