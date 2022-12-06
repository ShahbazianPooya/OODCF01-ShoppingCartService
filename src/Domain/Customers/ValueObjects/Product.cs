using CustomerBasketManagement.Domain.Common;
using CustomerBasketManagement.Domain.Customers.Exceptions;

namespace CustomerBasketManagement.Domain.Customers.ValueObjects
{
    public class Product : ValueObject<Product>
    {
        private static List<Product> AllExistProduct => new()
        {
            new Product("Mive", "1", 100, 500),
            new Product("Lebas", "2", 10, 60),
            new Product("Mobile", "3", 1000, 2)
        };

        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
        public int RemainingCount { get; private set; }

        public Product(string name, string code, decimal price, int quantity)
        {
            if (string.IsNullOrEmpty(code))
                throw new InvalidProductException("code is empty");

            if (!AllExistProduct.Exists(x => x.Code == code))
                throw new InvalidProductException("cant find the product");

            if (RemainingCount < quantity)
                throw new InvalidProductException("remaining count is less than order quantity");

            Name = name;
            Code = code;
            Price = price;
            RemainingCount -= quantity;
        }

        protected override bool EqualCore(Product obj)
        {
            return ReferenceEquals(this, obj)
                   && obj.Code == Code
                   && obj.Price == Price
                   && obj.Name == Name;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Name, Code, Price);
        }
    }
}
