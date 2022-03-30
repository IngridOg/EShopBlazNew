using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class InvoiceLineModel
{
    public int InvoiceId { get; set; }
    public int InvoiceLineNr { get; set; }
    public int Quantity { get; set; } = 0;
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; } = 0;
}
