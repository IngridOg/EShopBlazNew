using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class CreateCustomerModel
{
    public CreateCustomerModel()
    {
        Invoices = new HashSet<InvoiceModel>();
        ShoppingCarts = new HashSet<ShoppingCartModel>();
    }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? PhoneNr { get; set; }
    public string? CareOffAddress { get; set; }
    public string StreetAddress { get; set; } = null!;
    public string ZipCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public virtual ICollection<InvoiceModel> Invoices { get; set; }
    public virtual ICollection<ShoppingCartModel> ShoppingCarts { get; set; }

}