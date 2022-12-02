namespace CartService;
public class CartService
{
    private IDiscountService _dcs;
    private IExtraItemService _eis;
    public CartService(IDiscountService dcs, IExtraItemService eis)
    {
        _dcs = dcs;
        _eis = eis;
    }
    private List<CartItem> cartItems = new();
    public void AddCartItem(int productId,int quantity,int unitPrice)
    {
        var cartItem = new CartItem(productId,quantity,unitPrice);
        cartItems.Add(cartItem);
    }

    public void ApplyDiscount(Discount discount)
    {

    }

    public void ApplyExtraItem(ExtraItem extraItem)
    {
        
    }
        

    public double GetTotalPrice()
    {
        var discountPrice = _dcs.CalculateDiscount(cartItems);
        return 0;
    }

    public void ApplyDiscountCode(string code)
    {

    }
}
