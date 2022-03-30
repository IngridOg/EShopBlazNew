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

    public async Task CreateCustomer(CreateCustomerModel customer)
    {

        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        await _http.PostAsJsonAsync<CreateCustomerModel>("/api/customers", customer);

        // HttpResponseMessage _response = await _http.PostAsJsonAsync<Customer>("/api/customers", customer);

        // Return the customer that was created or null if none was created.
        // return await _response.Content.ReadFromJsonAsync<Customer>();
    }


    public async Task<IEnumerable<CustomerModel>> GetCustomers()
    {
        // forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        // customers = await Http.GetFromJsonAsync<Customer[]>("https://localhost:5001/api/customers");

        // Should we use List<Customer> or IEnumerable<Customer> ?
        // Shoud we use the route api/customers or api/customers/all ?

        // Returns a list of all customers or null.

        return await _http.GetFromJsonAsync<List<CustomerModel>>("/api/customers");
    }

    public async Task<CustomerModel> GetCustomer(int id)
    {
        // Return the customer or null.
        return await _http.GetFromJsonAsync<CustomerModel>("/api/customers/{id}");
    }

    public async Task UpdateCustomer(int id, CustomerModel customer)
    {
        if (customer == null)
            throw new ArgumentNullException(nameof(customer));

        await _http.PostAsJsonAsync($"/api/customers/{id}", customer);

        // HttpResponseMessage _response = await _http.PostAsJsonAsync($"/api/customers/{id}", customer);

        // Return the customer that was updated or null.
        // return await _response.Content.ReadFromJsonAsync<Customer>();
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

