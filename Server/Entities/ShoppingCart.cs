using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            Details = new HashSet<Detail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? CouponCode { get; set; }
        public byte ShippingType { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<Detail> Details { get; set; }
    }
}
