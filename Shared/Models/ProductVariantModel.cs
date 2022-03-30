using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBlazNew.Shared.Models;

public enum ProductSize
{
    NoSize = 0,
    XS = 1,
    S = 2,
    M = 3,
    L = 4,
    XL = 5,
    XXL = 6
}
public enum ShoeSize
{
    NoSize = 0,
    S35 = 1,
    S36 = 2,
    S37 = 3,
    S38 = 4,
    S39 = 5,
    S40 = 6,
    S41 = 7,
    S42 = 8,
    S43 = 9
}

public enum ProductColor
{
    NoColor = 0,
    Blue = 1,
    Green = 2,
    Red = 3,
    Yellow = 4,
    Orange = 5,
    Violette = 6,
    Pink = 7,
    Brown = 8,
    Beige = 9,
    White = 10,
    Black = 11
}
public class ProductVariantModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal ListPrice { get; set; } = 0;
    public decimal Price { get; set; } = 0;
    public string? ImageUrl { get; set; }
    public ProductSize Size { get; set; } = 0;
    public ProductColor Color { get; set; } = 0;
    public int NumberInStock { get; set; } = 0;
    public bool OnSale { get; set; } = false;

    public virtual ProductModel? OwnProduct { get; set; }
}
