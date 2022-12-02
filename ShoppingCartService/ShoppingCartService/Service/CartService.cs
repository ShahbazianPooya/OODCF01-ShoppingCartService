namespace ShoppingCartService.Service;

public class CartService
{
    private readonly ICartRepo _cartRepo;
    public CartService(ICartRepo cartRepo)
    {
        _cartRepo = cartRepo;
    }


    public void AddItem(int productId, int unitPrice, int cartId)
    {
        var cart = _cartRepo.GetCartById(cartId);
        if (cart == null)
            cart = Cart.InitializeCart();
        
        cart.AddItem(productId, unitPrice);
        
        _cartRepo.Save();
    }

    public void RemoveItem(int productId, int cartId)
    {
        var cart = _cartRepo.GetCartById(cartId);
        if (cart != null)
            cart.RemoveItem(productId);
    }

    public void Checkout(Address address, int cartId)
    {
        var cart = _cartRepo.GetCartById(cartId);
        // TODO
        
    }

    public void SetShippingMethod(ShippingMethod method)
    {
        // TODO
    }

    public void SetPackagingMethod(PackagingMethod method)
    {
        // TODO
    }
}