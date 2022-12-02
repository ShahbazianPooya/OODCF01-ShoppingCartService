namespace CartService;

public interface IDiscountService
{
    int CalculateDiscount(List<CartItem> cartItem);
}