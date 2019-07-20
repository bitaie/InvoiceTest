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
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _ItemService;
    

        public ItemsController(IItemService ItemService)
        {
    
            _ItemService = ItemService;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Item> GetItem()
        {
            return _ItemService.GetItems();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Item = await _context.Item.FindAsync(id);
            var Item = await _ItemService.GetItemAsync(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Ok(Item);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] int id, [FromBody] Item Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Item.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Item).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                await _ItemService.UpdateItemAsync(Item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_ItemService.ItemExists(id))
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

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] Item Item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //_context.Item.Add(Item);



            //await _context.SaveChangesAsync();

            await _ItemService.InsertItemAsync(Item);


            return CreatedAtAction("GetItem", new { id = Item.Id }, Item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var Item = await _context.Item.FindAsync(id);
            var Item = _ItemService.GetItem(id);
            if (Item == null)
            {
                return NotFound();
            }

            //_context.Item.Remove(Item);
            //await _context.SaveChangesAsync();
            await _ItemService.DeleteItemAsync(id);

            return Ok(Item);
        }


    }
}