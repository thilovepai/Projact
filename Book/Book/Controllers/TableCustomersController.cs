using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book.Models;

namespace Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableCustomersController : ControllerBase
    {
        private readonly Book04Context _context;

        public TableCustomersController(Book04Context context)
        {
            _context = context;
        }

        // GET: api/TableCustomers
        [HttpGet]
        public IEnumerable<TableCustomer> GetTableCustomer()
        {
            var TableCustomer = from cus in _context.TableCustomer
                           select new
                           {
                               cus.Idcus,
                               cus.NameCus,
                               cus.Tel,
                               cus.Idcard
                           };



            return _context.TableCustomer;
        }

        // GET: api/TableCustomers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableCustomer = await _context.TableCustomer.FindAsync(id);

            if (tableCustomer == null)
            {
                return NotFound();
            }
            

            return Ok(tableCustomer);
        }

        // PUT: api/TableCustomers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableCustomer([FromRoute] int id, [FromBody] TableCustomer tableCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableCustomer.Idcus)
            {
                return BadRequest();
            }

            _context.Entry(tableCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableCustomerExists(id))
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

        // POST: api/TableCustomers
        [HttpPost]
        public async Task<IActionResult> PostTableCustomer([FromBody] TableCustomer tableCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TableCustomer.Add(tableCustomer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableCustomer", new { id = tableCustomer.Idcus }, tableCustomer);
        }

        // DELETE: api/TableCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableCustomer = await _context.TableCustomer.FindAsync(id);
            if (tableCustomer == null)
            {
                return NotFound();
            }

            _context.TableCustomer.Remove(tableCustomer);
            await _context.SaveChangesAsync();

            return Ok(tableCustomer);
        }

        private bool TableCustomerExists(int id)
        {
            return _context.TableCustomer.Any(e => e.Idcus == id);
        }
    }
}