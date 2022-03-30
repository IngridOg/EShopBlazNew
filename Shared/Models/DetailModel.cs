using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class DetailModel
{
    public int ShoppingCartId { get; set; }
    public int RowNr { get; set; }
    public int Quantity { get; set; } = 0;
    public int SubTotal { get; set; } = 0;
    public int ProductVariantId { get; set; }

    public virtual ProductVariantModel? ProductVariant { get; set; }
}
