#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using EShopBlazNew.Shared.Models;
using EShopBlazNew.Server.Data;
using EShopBlazNew.Server.Entities;

namespace EShopBlazNew.Server.Controllers;

[Route("api/[controller]")]

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ProductsController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // POST: api/Products
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ProductModel>> PostProduct(CreateProductModel model)
    {
        Product product;
        ProductModel productModel;

        try
        {
            product = _mapper.Map<Product>(model);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

        productModel = _mapper.Map<ProductModel>(product);

        return CreatedAtAction("GetProduct", new { id = productModel.Id }, productModel);
    }

   // GET: api/Products
   [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetProducts()
    {
        IEnumerable<Product> dbProducts;
        List<ProductModel> productModels = new();

        try
        {
            dbProducts = await _context.Products
                .Include(p => p.ProductVariants)
                .ToListAsync();
            foreach (var p in dbProducts)
                productModels.Add(_mapper.Map<ProductModel>(p));
        }
        catch (Exception ex)
        {
            throw;
        }

        return productModels;
    }

    [HttpGet("[action]/{category}")]
    public async Task<ActionResult<IEnumerable<ProductModel>>> GetByCategory(int category)
    {
        IEnumerable<Product> dbProducts;
        List<ProductModel> productModels = new();

        try
        {
            dbProducts = await _context.Products
                .Where(x => x.Category == (byte)category)
                .Include(p => p.ProductVariants)
                .ToListAsync();
            foreach (var p in dbProducts)
                productModels.Add(_mapper.Map<ProductModel>(p));
        }
        catch (Exception ex)
        {
            throw;
        }

        return productModels;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> GetProduct(int id)
    {
        Product product;
 //       int idInt;

        try
        {
//            idInt = Int32.Parse(id);
            product = await _context.Products
                        .Include(p => p.ProductVariants)
                        .SingleOrDefaultAsync(p => p.Id == id);
        }
        catch (Exception ex)
        {
            throw;
        }

        if (product == null)
        {
            return NotFound();
        }

        var productModel = _mapper.Map<ProductModel>(product);
        return productModel;
    }

    // PUT: api/Products/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, ProductModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        var product = _mapper.Map<Product>(model);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Products/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        try
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }



}
