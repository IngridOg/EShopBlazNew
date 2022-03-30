using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class CreateProductModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Material { get; set; }
    public string? Care { get; set; }
    public string? Brand { get; set; }
    public string? Supplier { get; set; }

    public ProductCategory Category { get; set; } = 0;
    public byte SubCategory { get; set; } = 0;
    public SellingSeason Season { get; set; } = 0;
}
