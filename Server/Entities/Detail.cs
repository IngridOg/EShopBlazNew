using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class Detail
    {
        public int ShoppingCartId { get; set; }
        public int RowNr { get; set; }
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; } = null!;
    }
}
