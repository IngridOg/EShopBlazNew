using System;
using System.Collections.Generic;

namespace EShopBlazNew.Server.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            ShoppingCarts = new HashSet<ShoppingCart>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNr { get; set; }
        public string? CareOffAddress { get; set; }
        public string StreetAddress { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
