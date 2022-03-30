using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public enum TypeOfPayment
{
    NoValue = 0,
    Bank = 1,
    Card = 2,
    CashOnDelivery = 3,
    PayPal = 4
}
public enum TypeOfShipping
{
    NoValue = 0,
    FlatRate = 1,
    Free = 2,
    LocalPickup = 3
}
public class InvoiceModel
{
    public InvoiceModel()
    {
        InvoiceLines = new HashSet<InvoiceLineModel>();
    }

    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public DateTime? OrderDate { get; set; }
    public decimal Total { get; set; } = 0;
    public string? CouponCode { get; set; }
    public TypeOfShipping ShippingType { get; set; } = 0;
    public TypeOfPayment PaymentType { get; set; } = 0;
    public bool PayedFor { get; set; } = false;
    public string CustomerFirstName { get; set; } = null!;
    public string CustomerLastName { get; set; } = null!;
    public string? CustomerCareOffAddress { get; set; }
    public string CustomerStreetAddress { get; set; } = null!;
    public string CustomerZipCode { get; set; } = null!;
    public string CustomerCity { get; set; } = null!;

    public virtual ICollection<InvoiceLineModel> InvoiceLines { get; set; }
}
