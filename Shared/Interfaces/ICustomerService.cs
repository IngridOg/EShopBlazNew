using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopBlazNew.Shared.Models;

namespace EShopBlazNew.Shared.Interfaces;

public interface ICustomerService
{
    Task CreateCustomer(CreateCustomerModel customer);
    Task<IEnumerable<CustomerModel>> GetCustomers();
    Task<CustomerModel> GetCustomer(int id);
    Task UpdateCustomer(int id, CustomerModel customer);
    Task DeleteCustomer(int id);

    //Task CreateInvoice(InvoiceModel invoice);
    //Task<IEnumerable<InvoiceModel>> GetInvoices();
    //Task<InvoiceModel> GetInvoice(int id);

    //Task CreateShoppingCart(ShoppingCartModel shoppingCart);
    //Task<IEnumerable<ShoppingCartModel>> GetShoppingCarts();
    //Task<ShoppingCartModel> GetShoppingCart(int id);
    //Task UpdateShoppingCart(int id, ShoppingCartModel shoppingCart);
    //Task DeleteShoppingCart(int id);
 
}
