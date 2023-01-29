using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Control_de_Visitas.Models;

namespace Control_de_Visitas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorteroesController : ControllerBase
    {
        private readonly Control_d_VisitasContext _context;

        public PorteroesController(Control_d_VisitasContext context)
        {
            _context = context;
        }

        // GET: api/Porteroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Portero>>> GetPorteros()
        {
            return await _context.Porteros.ToListAsync();
        }

        // GET: api/Porteroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Portero>> GetPortero(int id)
        {
            var portero = await _context.Porteros.FindAsync(id);

            if (portero == null)
            {
                return NotFound();
            }

            return portero;
        }

        // PUT: api/Porteroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortero(int id, Portero portero)
        {
            if (id != portero.IdPortero)
            {
                return BadRequest();
            }

            _context.Entry(portero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorteroExists(id))
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

        // POST: api/Porteroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Portero>> PostPortero(Portero portero)
        {
            _context.Porteros.Add(portero);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PorteroExists(portero.IdPortero))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPortero", new { id = portero.IdPortero }, portero);
        }

        // DELETE: api/Porteroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortero(int id)
        {
            var portero = await _context.Porteros.FindAsync(id);
            if (portero == null)
            {
                return NotFound();
            }

            _context.Porteros.Remove(portero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PorteroExists(int id)
        {
            return _context.Porteros.Any(e => e.IdPortero == id);
        }
    }
}
