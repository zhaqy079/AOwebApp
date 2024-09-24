using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AOWebApp.Data;
using AOWebApp.Models;


namespace AOWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsWebAPIController : ControllerBase
    {
        private readonly AmazonOrdersContext _context;

        public ItemsWebAPIController(AmazonOrdersContext context)
        {
            _context = context;
        }

        // GET: api/ItemsWebAPI
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        //{
        //    return await _context.Items.ToListAsync();
        //}
        [HttpGet]
        // Prac 07 Modify the WebAPI
        // include optional SearchText str and CategoryID int in the Get action
        // so it can locate items by matching name and item category 
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(string? SearchText, int? CategoryID)
        {
            // 1 If there no SearchText value and no CategoryID value then the query should return all items
            var query = _context.Items
                .OrderBy(i => i.ItemName)
                .AsQueryable();
            // 2 If the SearchText is not an empty string or null, then the query should be modified
            // so it can limit the items returned to any item that has the searchText in the itemName
            if (!string.IsNullOrWhiteSpace(SearchText))
            {
                query = query.Where(i => i.ItemName.Contains(SearchText));
            }
            // 3 if the CategoryID has a value then the query should return items
            // whose category parentCategoryID matched the Category value
            if (CategoryID.HasValue)
            {
                query = query.Where(i => i.Category.ParentCategoryId == CategoryID);
            }
            // 4 Return the items in order of itemName 
            return await query.ToListAsync();
        }

        // GET: api/ItemsWebAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/ItemsWebAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/ItemsWebAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/ItemsWebAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
