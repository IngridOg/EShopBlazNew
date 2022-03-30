using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class ShoppingCartModel
{
    public ShoppingCartModel()
    {
        Details = new HashSet<DetailModel>();
    }

    public int Id { get; set; }
    public string? CouponCode { get; set; }
    public TypeOfShipping ShippingType { get; set; } = 0;

    public virtual ICollection<DetailModel> Details { get; set; }
}