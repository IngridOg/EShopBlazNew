using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EShopBlazNew.Client;
using EShopBlazNew.Shared.Interfaces;
using EShopServicesClassLib.Services; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ICustomerService, CustomerService>(client => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);});
builder.Services.AddHttpClient<IProductService, ProductService>(client => { client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
