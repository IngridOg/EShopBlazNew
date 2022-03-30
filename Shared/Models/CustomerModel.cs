using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class CustomerModel
{
    public CustomerModel()
    {
        InvoiceModels = new HashSet<InvoiceModel>();
        ShoppingCartModels = new HashSet<ShoppingCartModel>();
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNr { get; set; }
    public string? CareOffAddress { get; set; }
    public string StreetAddress { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }

    public virtual ICollection<InvoiceModel> InvoiceModels { get; set; }
    public virtual ICollection<ShoppingCartModel> ShoppingCartModels { get; set; }
}
