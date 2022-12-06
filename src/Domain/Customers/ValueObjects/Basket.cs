using CustomerBasketManagement.Domain.Common;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class Basket : ValueObject<Basket>
    {
        public static Basket Empty = new();
        public List<BasketItem> BasketItems { get; private set; }
        public decimal TotalPrice => BasketItems.Sum(x => x.Product.Price);

        public Basket()
        {
            BasketItems = new List<BasketItem>();
        }

        public void AddBasketItems(string productName, string productCode, decimal productPrice, int quantity)
        {
            BasketItems.Add(new BasketItem(productName, productCode, productPrice, quantity));
        }

        protected override bool EqualCore(Basket obj)
        {
            if (ReferenceEquals(this, obj)
                && obj.BasketItems.Count == BasketItems.Count)
                return true;

            return false;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(BasketItems.Count, TotalPrice);
        }
    }
}
