using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using EShopBlazNew.Shared.Models;
using EShopBlazNew.Shared.Interfaces;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EShopServicesClassLib.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient httpClient)
    {
        _http = httpClient;
    }

    //  CRUD for Product
    public async Task<ProductModel> CreateProduct(CreateProductModel createProductModel)
    {
        if (createProductModel == null)
            throw new ArgumentNullException(nameof(createProductModel));

        var result = await _http.PostAsJsonAsync("/api/products", createProductModel);

        if (result.IsSuccessStatusCode == false)
        {
            string message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
        else
        {
            return await result.Content.ReadFromJsonAsync<ProductModel>();
        }
    }


    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        // Returns a list of all products or null.
        return await _http.GetFromJsonAsync<List<ProductModel>>("/api/products");
    }

    public async Task<IEnumerable<ProductModel>> GetProducts(int category)
    {
        // Returns a list of all products in specified category or null.
        return await _http.GetFromJsonAsync<List<ProductModel>>($@"/api/products/GetByCategory/{category}");
    }

    public async Task<ProductModel> GetProduct(int id)
    {
        // Return the product or null.
        return await _http.GetFromJsonAsync<ProductModel>($"/api/products/{id}");
    }

    public async Task UpdateProduct(int id, ProductModel productModel)
    {
        if (productModel == null)
            throw new ArgumentNullException(nameof(productModel));

        await _http.PostAsJsonAsync($"/api/products/{id}", productModel);
    }

    public async Task DeleteProduct(int id)
    {
        await _http.DeleteAsync($"/api/products/{id}");
    }

    //  CRUD for ProductVariant
    public async Task<ProductVariantModel> CreateProductVariant(CreateProductVariantModel createProductVariantModel)
    {
        if (createProductVariantModel == null)
            throw new ArgumentNullException(nameof(createProductVariantModel));

        var result = await _http.PostAsJsonAsync<CreateProductVariantModel>("/api/productvariants", createProductVariantModel);

        if (result.IsSuccessStatusCode == false)
        {
            string message = await result.Content.ReadAsStringAsync();
            throw new Exception(message);
        }
        else
        {
            return await result.Content.ReadFromJsonAsync<ProductVariantModel>();
        }
    }

    public async Task UpdateProductVariant(int id, ProductVariantModel productVariantModel)
    {
        if (productVariantModel == null)
            throw new ArgumentNullException(nameof(productVariantModel));

        await _http.PostAsJsonAsync($"/api/productvariants/{id}", productVariantModel);
    }

    public async Task DeleteProductVariant(int id)
    {
        await _http.DeleteAsync($"/api/productvariants/{id}");
    }
}



