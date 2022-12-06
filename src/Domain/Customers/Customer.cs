using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Enums;
using CustomerBasketManagement.Domain.Customers.ValueObjects;

namespace CustomerBasketManagement.Domain.Customers
{
    public class Customer : AggregateRoot<int>
    {
        public string FullName { get; private set; }
        public Address Address { get; private set; }
        public CreditCard CreditCard { get; private set; }
        public Basket Basket { get; private set; }

        public Customer(string fullName)
        {
            FullName = fullName;
            Address = Address.Empty;
            CreditCard = CreditCard.Empty;
            Basket = Basket.Empty;
        }

        public void SetAddress(string addressName)
        {
            Address = new Address(addressName);
        }

        public void SetCreditCard(DateTime expirationDate, string cardNumber)
        {
            CreditCard = new CreditCard(expirationDate, FullName, cardNumber);
        }

        public void AddBasketItems(string productName, string productCode, decimal productPrice, int quantity)
        {
            Basket.AddBasketItems(productName, productCode, productPrice, quantity);
        }

        public void BuyBasket(DeliveryType deliveryType, PackageType packageType)
        {
            if (Basket.Equals(Basket.Empty))
                throw new InvalidOperationException("basket is empty");

            if (Address.Equals(Address.Empty))
                throw new InvalidOperationException("adress is empty");

            if (CreditCard.Equals(CreditCard.Empty))
                throw new InvalidOperationException("credit card is empty");

            Delivery delivery = new(deliveryType);

            Package package = new(packageType);

            var basketPrice = package.Price + delivery.Price + Basket.TotalPrice;

            CreditCard.Pay(CreditCard, basketPrice);
        }
    }
}
