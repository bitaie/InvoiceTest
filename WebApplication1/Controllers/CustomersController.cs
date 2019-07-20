using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using DomainServices.Services;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;

        public CustomersController(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomer()
        {
            return _CustomerService.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Customer = await _context.Customer.FindAsync(id);
            var Customer =await  _CustomerService.GetCustomerAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer( [FromBody] Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != Customer.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(Customer).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
               await _CustomerService.UpdateCustomerAsync(Customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!_CustomerService.CustomerExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Customer.Add(Customer);



            //await _context.SaveChangesAsync();
            
            await _CustomerService.InsertCustomerAsync(Customer);


            return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Customer = await _context.Customer.FindAsync(id);
            Customer Customer = _CustomerService.GetCustomer(id);
            if (Customer == null)
            {
                return NotFound();
            }

            //_context.Customer.Remove(Customer);
            //await _context.SaveChangesAsync();
           await _CustomerService.DeleteCustomerAsync(id);

            return Ok(Customer);
        }


    }
}