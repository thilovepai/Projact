﻿using System;
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
    public class TableOrdersController : ControllerBase
    {
        private readonly Book04Context _context;

        public TableOrdersController(Book04Context context)
        {
            _context = context;
        }

        // GET: api/TableOrders
        [HttpGet]
        public IEnumerable<TableOrder> GetTableOrder()
        {
            var TableOrder = from cus in _context.TableOrder
                                select new
                                {
                                    cus.Idcus,
                                    cus.Idorder,
                                    cus.DateOrder
                                    
                                };
            return _context.TableOrder;
        }

        // GET: api/TableOrders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTableOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableOrder = await _context.TableOrder.FindAsync(id);

            if (tableOrder == null)
            {
                return NotFound();
            }

            return Ok(tableOrder);
        }

        // PUT: api/TableOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableOrder([FromRoute] int id, [FromBody] TableOrder tableOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tableOrder.Idorder)
            {
                return BadRequest();
            }

            _context.Entry(tableOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableOrderExists(id))
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

        // POST: api/TableOrders
        [HttpPost]
        public async Task<IActionResult> PostTableOrder([FromBody] TableOrder tableOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TableOrder.Add(tableOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableOrder", new { id = tableOrder.Idorder }, tableOrder);
        }

        // DELETE: api/TableOrders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tableOrder = await _context.TableOrder.FindAsync(id);
            if (tableOrder == null)
            {
                return NotFound();
            }

            _context.TableOrder.Remove(tableOrder);
            await _context.SaveChangesAsync();

            return Ok(tableOrder);
        }

        private bool TableOrderExists(int id)
        {
            return _context.TableOrder.Any(e => e.Idorder == id);
        }
    }
}