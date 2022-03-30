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
public class CustomersController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CustomersController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // POST: api/Customers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CustomerModel>> PostCustomer(CreateCustomerModel model)
    {
        Customer customer;
        CustomerModel customerModel;

        try
        {
            customer = _mapper.Map<Customer>(model);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }

        customerModel = _mapper.Map<CustomerModel>(customer);

        return CreatedAtAction("GetCustomer", new { id = customerModel.Id }, customerModel);
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
    {
        IEnumerable<Customer> dbCustomers;
        List<CustomerModel> customerModels = new();

        try
        {
            dbCustomers = await _context.Customers.ToListAsync();
            foreach (var c in dbCustomers)
                customerModels.Add(_mapper.Map<CustomerModel>(c));
        }
        catch (Exception ex)
        {
            throw;
        }

        return customerModels;
    }

    // GET: api/Customers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
    {
        Customer customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        var customerModel = _mapper.Map<CustomerModel>(customer);
        return customerModel;
    }

    // PUT: api/Customers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, CustomerModel model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        var customer = _mapper.Map<Customer>(model);
        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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



    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }

        try
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }

        return NoContent();
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Id == id);
    }
}

