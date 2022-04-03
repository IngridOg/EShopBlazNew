using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public class CreateProductVariantModel
{
    public int ProductId { get; set; }  
    public decimal ListPrice { get; set; } = 0;
    public decimal Price { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public byte Size { get; set; } = 0;
    public ProductColor Color { get; set; } = 0;
    public int NumberInStock { get; set; } = 0;
    public bool OnSale { get; set; } = false;
}
