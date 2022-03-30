using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class InvoiceLine
    {
        public int InvoiceId { get; set; }
        public int InvoiceLineNr { get; set; }
        public int Quantity { get; set; }
        public int ProductVariantId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
    }
}
