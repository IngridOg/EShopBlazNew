using EShopBlazNew.Shared.Models;

namespace EShopBlazNew.Client;

static class Globals
{
    public static CreateCustomerModel Customer = new CreateCustomerModel();
    public static ShoppingCartModel ShoppingCart = new ShoppingCartModel();
    public static UserModel User = new UserModel();

    public const int ShippingFlatRate = 20;
    public const int ShippingFree = 0;
    public const int ShippingLocalPickup = 25;
}
