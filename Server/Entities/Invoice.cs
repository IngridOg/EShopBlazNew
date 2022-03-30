using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public string? CouponCode { get; set; }
        public byte ShippingType { get; set; }
        public byte PaymentType { get; set; }
        public bool PayedFor { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string? CustomerCareOffAddress { get; set; }
        public string CustomerStreetAddress { get; set; } = null!;
        public string CustomerZipCode { get; set; } = null!;
        public string CustomerCity { get; set; } = null!;

        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
    }
}
