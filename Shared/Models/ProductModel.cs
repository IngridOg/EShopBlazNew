using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;



public enum SellingSeason
{
    NoValue = 0,
    Winter = 1,
    Spring = 2,
    Summer = 3,
    Autumn = 4
}

public class ProductModel
{
    public ProductModel()
    {
        ProductVariants = new HashSet<ProductVariantModel>();
    }
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Material { get; set; }
    public string? Care { get; set; }
    public string? Brand { get; set; }
    public string? Supplier { get; set; }

    public ProductCategory Category { get; set; } = 0;
    public byte SubCategory { get; set; } = 0;
    public SellingSeason Season { get; set; } = 0;

    public virtual ICollection<ProductVariantModel> ProductVariants { get; set; }


}
