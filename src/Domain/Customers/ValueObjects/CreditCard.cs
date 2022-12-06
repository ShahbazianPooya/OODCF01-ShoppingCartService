using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Exceptions;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class CreditCard : ValueObject<CreditCard>
    {
        public static CreditCard Empty = new(new DateTime(0001, 01, 01), string.Empty, string.Empty);
        public decimal CardBalance { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string OwnerName { get; private set; }
        public string CardNumber { get; private set; }

        public CreditCard(DateTime expirationDate, string ownerName, string cardNumber)
        {
            if (expirationDate <= DateTime.Now)
                throw new InvalidCreditCardException("card is expired");

            if (string.IsNullOrEmpty(ownerName))
                throw new InvalidCreditCardException("owner name is empty");

            if (string.IsNullOrEmpty(cardNumber))
                throw new InvalidCreditCardException("card number is empty");

            ExpirationDate = expirationDate;
            OwnerName = ownerName;
            CardNumber = cardNumber;
            CardBalance = 10000; // should get data from bank service
        }

        public void Pay(CreditCard creditCard, decimal totalPrice)
        {
            if (creditCard.CardBalance < totalPrice)
                throw new InvalidOperationException("card balance is not enough");

            creditCard.CardBalance -= totalPrice;
        }

        protected override bool EqualCore(CreditCard obj)
        {
            return GetType() == obj.GetType()
                && obj.OwnerName == OwnerName
                && obj.ExpirationDate == ExpirationDate
                && obj.CardNumber == CardNumber;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(ExpirationDate, CardNumber, OwnerName);
        }
    }
}
