namespace ShoppingCartService;

public interface ICartRepo
{
    public Cart GetCartById(int cartId);

    public Cart CreateCart();

    public void Save();
}