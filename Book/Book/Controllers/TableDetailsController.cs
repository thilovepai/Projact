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
    public class TableDetailsController : ControllerBase
    {
        private readonly Book04Context _context;

        public TableDetailsController(Book04Context context)
        {
            _context = context;
        }

        // GET: api/TableDetails
        [HttpGet]
        public IEnumerable<TableDetail> GetTableDetail()
        {
            var TableDetail = from cus in _context.TableDetail
                              select new
                             {
                                 cus.Iddetail,
                                 cus.OrderNum,
                                 cus.Idbook,
                                 cus.Numbook,
                                 cus.Idorder,
                                 cus.Total

                              };
            return _context.TableDetail;
        }

        // GET: api/TableDetails/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableDetail = await _context.TableDetail.FindAsync(id);

            if (tableDetail == null)
            {
                return NotFound();
            }


            return Ok(tableDetail);
        }

        // PUT: api/TableDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableDetail([FromRoute] int id, [FromBody] TableDetail tableDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableDetail.Iddetail)
            {
                return BadRequest();
            }

            _context.Entry(tableDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableDetailExists(id))
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

        // POST: api/TableDetails
        [HttpPost]
        public async Task<IActionResult> PostTableDetail([FromBody] TableDetail tableDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TableDetail.Add(tableDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableDetail", new { id = tableDetail.Iddetail }, tableDetail);
        }

        // DELETE: api/TableDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableDetail([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableDetail = await _context.TableDetail.FindAsync(id);
            if (tableDetail == null)
            {
                return NotFound();
            }

            _context.TableDetail.Remove(tableDetail);
            await _context.SaveChangesAsync();

            return Ok(tableDetail);
        }

        private bool TableDetailExists(int id)
        {
            return _context.TableDetail.Any(e => e.Iddetail == id);
        }
    }
}