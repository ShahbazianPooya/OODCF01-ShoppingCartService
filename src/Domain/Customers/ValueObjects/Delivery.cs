using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Enums;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class Delivery : ValueObject<Delivery>
    {
        private readonly DeliveryType _deliveryType;
        public decimal Price { get; private set; }

        public Delivery(DeliveryType deliveryType)
        {
            _deliveryType = deliveryType;
            Price = _deliveryType == DeliveryType.Normal ? 0 : 100;
        }

        protected override bool EqualCore(Delivery obj)
        {
            return GetType() == obj.GetType()
                   && Price == obj.Price;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(_deliveryType, Price);
        }
    }
}
