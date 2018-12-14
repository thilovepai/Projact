using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Models;
using Microsoft.AspNetCore.Cors;

namespace Book.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TableBooksController : ControllerBase
    {
        private readonly Book04Context _context;

        public TableBooksController(Book04Context context)
        {
            _context = context;
        }

        // GET: api/TableBooks
        [HttpGet]
        public IEnumerable<TableBook> GetTableBook()
        {
            var Customer = from cus in _context.TableBook
                           select new
                           {
                               cus.Idbook,
                               cus.NameBook,
                               cus.DetailBook,
                               cus.PriceBook,
                               cus.PictureBook
                           };
            return _context.TableBook;
        }

        // GET: api/TableBooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableBook = await _context.TableBook.FindAsync(id);

            if (tableBook == null)
            {
                return NotFound();
            }

            return Ok(tableBook);
        }

        // PUT: api/TableBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableBook([FromRoute] int id, [FromBody] TableBook tableBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableBook.Idbook)
            {
                return BadRequest();
            }

            _context.Entry(tableBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableBookExists(id))
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

        // POST: api/TableBooks
        [HttpPost]
        public async Task<IActionResult> PostTableBook([FromBody] TableBook tableBook)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TableBook.Add(tableBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TableBookExists(tableBook.Idbook))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetTableBook", new { id = tableBook.Idbook }, tableBook);
        }

        // DELETE: api/TableBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableBook = await _context.TableBook.FindAsync(id);
            if (tableBook == null)
            {
                return NotFound();
            }

            _context.TableBook.Remove(tableBook);
            await _context.SaveChangesAsync();

            return Ok(tableBook);
        }

        private bool TableBookExists(int id)
        {
            return _context.TableBook.Any(e => e.Idbook == id);
        }
    }
}