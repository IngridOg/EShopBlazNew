using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public byte Size { get; set; }
        public byte Color { get; set; }
        public int NumberInStock { get; set; }
        public bool OnSale { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
