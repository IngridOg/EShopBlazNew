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

namespace EShopBlazNew.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductVariantsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductVariantModel>> PostProductVariant(CreateProductVariantModel model)
        {
            Product product;
            ProductVariant productVariant;
            ProductVariantModel productVariantModel;

            try
            {
                product = await _context.Products.FindAsync(model.ProductId);
                if (product == null)
                {
                    return BadRequest();
                }
                productVariant = _mapper.Map<ProductVariant>(model);
                product.ProductVariants.Add(productVariant);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            productVariantModel = _mapper.Map<ProductVariantModel>(productVariant);

            return CreatedAtAction("GetProductVariant", new { id = productVariantModel.Id }, productVariantModel);
        }

        // GET: api/ProductVariants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVariantModel>> GetProductVariant(int id)
        {
            ProductVariant productVariant = await _context.ProductVariants.FindAsync(id);

            if (productVariant == null)
            {
                return NotFound();
            }

            var productVariantModel = _mapper.Map<ProductVariantModel>(productVariant);
            return productVariantModel;
        }

        // PUT: api/ProductVariants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductVariant(int id, ProductVariantModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var productVariant = _mapper.Map<ProductVariant>(model);
            _context.Entry(productVariant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductVariantExists(id))
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



        // DELETE: api/ProductVariants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductVariant(int id)
        {
            Product product;
            ProductVariant productVariant;

            try
            {
                productVariant = await _context.ProductVariants.FindAsync(id);
                if (productVariant == null)
                {
                    return NotFound();
                }
                product = await _context.Products.FindAsync(productVariant.ProductId);
                if (product == null)
                {
                    return BadRequest();
                }
                product.ProductVariants.Remove(productVariant);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }


            return NoContent();
        }

        private bool ProductVariantExists(int id)
        {
            return _context.ProductVariants.Any(e => e.Id == id);
        }
    }
}
