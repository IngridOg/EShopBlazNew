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
//            return await result.Content.ReadFromJsonAsync<ProductModel>(new JsonSerializerOptions() 
//                { ReferenceHandler = ReferenceHandler.Preserve });
            return await result.Content.ReadFromJsonAsync<ProductModel>();
        }
    }


    public async Task<IEnumerable<ProductModel>> GetProducts()
    {
        //var options = new JsonSerializerOptions()
        //{
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};
//        return await _http.GetFromJsonAsync<List<ProductModel>>("/api/products", options);
        return await _http.GetFromJsonAsync<List<ProductModel>>("/api/products");
    }

    public async Task<IEnumerable<ProductModel>> GetProducts(int category)
    {
        //var options = new JsonSerializerOptions()
        //{
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};
//        return await _http.GetFromJsonAsync<List<ProductModel>>($@"/api/products/GetByCategory/{category}", options);
        return await _http.GetFromJsonAsync<List<ProductModel>>($@"/api/products/GetByCategory/{category}");
    }

    public async Task<ProductModel> GetProduct(int id)
    {
        //var options = new JsonSerializerOptions()
        //{
        //    ReferenceHandler = ReferenceHandler.Preserve
        //};

        // Return the product or null.
 //       return await _http.GetFromJsonAsync<ProductModel>($"/api/products/{id}", options);
        return await _http.GetFromJsonAsync<ProductModel>($"/api/products/{id}");
    }

    public async Task UpdateProduct(int id, ProductModel product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        await _http.PostAsJsonAsync($"/api/products/{id}", product);
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
 //           return await result.Content.ReadFromJsonAsync<ProductVariantModel>(new JsonSerializerOptions()
 //           { ReferenceHandler = ReferenceHandler.Preserve });
            return await result.Content.ReadFromJsonAsync<ProductVariantModel>();
        }
    }

    public async Task UpdateProductVariant(int id, ProductVariantModel productVariant)
    {
        if (productVariant == null)
            throw new ArgumentNullException(nameof(productVariant));

        await _http.PostAsJsonAsync($"/api/productvariants/{id}", productVariant);
    }

    public async Task DeleteProductVariant(int id)
    {
        await _http.DeleteAsync($"/api/productvariants/{id}");
    }
}



