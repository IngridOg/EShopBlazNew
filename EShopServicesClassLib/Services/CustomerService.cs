using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using EShopBlazNew.Shared.Models;
using EShopBlazNew.Shared.Interfaces;

namespace EShopServicesClassLib.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _http;

    public CustomerService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    //  CRUD for Customer
    public async Task<CustomerModel> CreateCustomer(CreateCustomerModel createCustomerModel)
    {
        if (createCustomerModel == null)
            throw new ArgumentNullException(nameof(createCustomerModel));

        var result = await _http.PostAsJsonAsync("/api/customers", createCustomerModel);

        if (result.IsSuccessStatusCode == false)
        {
            string message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
        else
        {
            return await result.Content.ReadFromJsonAsync<CustomerModel>();
        }
    }


    public async Task<IEnumerable<CustomerModel>> GetCustomers()
    {
        // Returns a list of all customers or null.

        return await _http.GetFromJsonAsync<List<CustomerModel>>("/api/customers");
    }

    public async Task<CustomerModel> GetCustomer(int id)
    {
        // Return the customer or null.
        return await _http.GetFromJsonAsync<CustomerModel>("/api/customers/{id}");
    }

    public async Task UpdateCustomer(int id, CustomerModel customerModel)
    {
        if (customerModel == null)
            throw new ArgumentNullException(nameof(customerModel));

        await _http.PostAsJsonAsync($"/api/customers/{id}", customerModel);
    }

    public async Task DeleteCustomer(int id)
    {
        await _http.DeleteAsync($"/api/customers/{id}");
    }

    //Task CreateInvoice(InvoiceModel invoice);
    //Task<IEnumerable<InvoiceModel>> GetInvoices();
    //Task<InvoiceModel> GetInvoice(int id);

    //Task CreateShoppingCart(ShoppingCartModel shoppingCart);
    //Task<IEnumerable<ShoppingCartModel>> GetShoppingCarts();
    //Task<ShoppingCartModel> GetShoppingCart(int id);
    //Task UpdateShoppingCart(int id, ShoppingCartModel shoppingCart);
    //Task DeleteShoppingCart(int id);
}

