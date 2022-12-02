namespace ShoppingCartService;

public class Cart
{
    private int _id;
    private List<CartItem> _items;
    private Dictionary<ShippingMethod, int> _shippingPrices;
    private Dictionary<PackagingMethod, int> _packagingPrices;
    private ShippingMethod _shippingMethod;
    private PackagingMethod _packagingMethod;
    private Address _address;
    private int _discountAmount;

    public Cart()
    {
        _items = new List<CartItem>();
        
        // TODO fill Dictionaries
    }

    public static Cart InitializeCart() => new Cart();

    public void AddItem(int productId, int unitPrice)
    {
        // TODO Validation
        var item = _items.FirstOrDefault(x => x.ProductId == productId);
        if (item == null)
            _items.Add(new CartItem()
            {
                Quantity = 1,
                ProductId = productId,
                UnitPrice = unitPrice
            });

        else
            item.Quantity++;
    }

    public void RemoveItem(int productId)
    {
        var item = _items.FirstOrDefault(x => x.ProductId == productId);
        if (item != null)
            item.Quantity--;
    }

    public void Checkout(Address address)
    {
        _address = address;
        
    }

    public void SetShippingMethod(ShippingMethod method)
    {
        _shippingMethod = method;
    }

    public void SetPackagingMethod(PackagingMethod method)
    {
        _packagingMethod = method;
    }

    private void ApplyDiscount(int discountAmount)
    {
        _discountAmount = discountAmount;
    }

    public int GetTotalAmount() =>
        _items.Sum(x => x.Quantity * x.UnitPrice) - _discountAmount + _shippingPrices[_shippingMethod] + _packagingPrices[_packagingMethod];
}