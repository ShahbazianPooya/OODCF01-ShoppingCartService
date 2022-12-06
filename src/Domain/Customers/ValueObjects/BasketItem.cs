using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Exceptions;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class BasketItem : ValueObject<BasketItem>
    {
        public int Quantity { get; private set; }
        public Product Product { get; private set; }

        public BasketItem(string productName, string productCode, decimal productPrice, int quantity)
        {
            if (quantity <= 0)
                throw new InvalidBasketItemException("quantity is less than zero");

            Quantity = quantity;
            Product = new(productName, productCode, productPrice, quantity);
        }

        protected override bool EqualCore(BasketItem obj)
        {
            return GetType() == obj.GetType()
                   && Quantity == obj.Quantity
                   && Product.Equals(obj.Product);
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Quantity, Product.GetHashCode());
        }
    }
}
