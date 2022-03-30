using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductVariants = new HashSet<ProductVariant>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Material { get; set; }
        public string? Care { get; set; }
        public string? Brand { get; set; }
        public string? Supplier { get; set; }
        public byte Category { get; set; }
        public byte SubCategory { get; set; }
        public byte Season { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }
}
