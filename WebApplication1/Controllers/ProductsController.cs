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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductsController(IProductService ProductService)
        {
            _ProductService = ProductService;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _ProductService.GetProducts();
        }  
        // GET: api/ProductsList
        [HttpGet]
        public IEnumerable<string> GetProductList()
        {
            return _ProductService.GetAllProductList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Product = await _context.Product.FindAsync(id);
            var Product = await _ProductService.GetProductAsync(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Product.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Product).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _ProductService.UpdateProductAsync(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ProductService.ProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product Product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Product.Add(Product);



            //await _context.SaveChangesAsync();

            await _ProductService.InsertProductAsync(Product);


            return CreatedAtAction("GetProduct", new { id = Product.Id }, Product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Product = await _context.Product.FindAsync(id);
            var Product = _ProductService.GetProduct(id);
            if (Product == null)
            {
                return NotFound();
            }

            //_context.Product.Remove(Product);
            //await _context.SaveChangesAsync();
            await _ProductService.DeleteProductAsync(id);

            return Ok(Product);
        }


    }
}