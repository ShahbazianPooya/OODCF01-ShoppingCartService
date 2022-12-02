namespace CartService;

public class CartItem
{

    public CartItem(int productId, int quantity, int unitPrice)
    {
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public int ProductId { get; private set; }
    public int Quantity { get; private set; }
    public int UnitPrice { get; private set; }
}