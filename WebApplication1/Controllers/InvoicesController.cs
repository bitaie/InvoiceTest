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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _InvoiceService;
        private readonly IItemService _ItemService;

        public InvoicesController(IInvoiceService InvoiceService, IItemService ItemService)
        {
            _InvoiceService = InvoiceService;
            _ItemService = ItemService;
        }

        // GET: api/Invoices
        [HttpGet]
        public IEnumerable<Invoice> GetInvoice()
        {
            return _InvoiceService.GetInvoices();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Invoice = await _context.Invoice.FindAsync(id);
            var Invoice = await _InvoiceService.GetInvoiceAsync(id);

            if (Invoice == null)
            {
                return NotFound();
            }

            return Ok(Invoice);
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice([FromRoute] int id, [FromBody] Invoice Invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Invoice.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Invoice).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _InvoiceService.UpdateInvoiceAsync(Invoice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_InvoiceService.InvoiceExists(id))
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

        // POST: api/Invoices
        [HttpPost]
        public async Task<IActionResult> PostInvoice([FromBody] Invoice Invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Invoice.Add(Invoice);



            //await _context.SaveChangesAsync();

            await _InvoiceService.InsertInvoiceAsync(Invoice);


            return CreatedAtAction("GetInvoice", new { id = Invoice.Id }, Invoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Invoice = await _context.Invoice.FindAsync(id);
            var Invoice = _InvoiceService.GetInvoice(id);
            if (Invoice == null)
            {
                return NotFound();
            }

            //_context.Invoice.Remove(Invoice);
            //await _context.SaveChangesAsync();
            await _InvoiceService.DeleteInvoiceAsync(id);

            return Ok(Invoice);
        }


    }
}