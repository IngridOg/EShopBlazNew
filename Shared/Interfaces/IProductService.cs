using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopBlazNew.Shared.Models;

namespace EShopBlazNew.Shared.Interfaces;
public interface IProductService
{
    Task<ProductModel> CreateProduct(CreateProductModel product);
//    Task<IEnumerable<ProductModel>> GetProducts();
    Task<IEnumerable<ProductModel>> GetProducts(int category);
    Task<ProductModel> GetProduct(int id);
    Task UpdateProduct(int id, ProductModel product);
    Task DeleteProduct(int id);


    //Task<IEnumerable<ProductVariantModel>> GetProductVariants(int productId);


    Task<ProductVariantModel> CreateProductVariant(CreateProductVariantModel productVariant);
    Task UpdateProductVariant(int id, ProductVariantModel productVariant);
    Task DeleteProductVariant(int id);
}
