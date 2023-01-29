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
    public class TipoVisitantesController : ControllerBase
    {
        private readonly Control_d_VisitasContext _context;

        public TipoVisitantesController(Control_d_VisitasContext context)
        {
            _context = context;
        }

        // GET: api/TipoVisitantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVisitante>>> GetTipoVisitantes()
        {
            return await _context.TipoVisitantes.ToListAsync();
        }

        // GET: api/TipoVisitantes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVisitante>> GetTipoVisitante(int id)
        {
            var tipoVisitante = await _context.TipoVisitantes.FindAsync(id);

            if (tipoVisitante == null)
            {
                return NotFound();
            }

            return tipoVisitante;
        }

        // PUT: api/TipoVisitantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVisitante(int id, TipoVisitante tipoVisitante)
        {
            if (id != tipoVisitante.IdTipo)
            {
                return BadRequest();
            }

            _context.Entry(tipoVisitante).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVisitanteExists(id))
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

        // POST: api/TipoVisitantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVisitante>> PostTipoVisitante(TipoVisitante tipoVisitante)
        {
            _context.TipoVisitantes.Add(tipoVisitante);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TipoVisitanteExists(tipoVisitante.IdTipo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTipoVisitante", new { id = tipoVisitante.IdTipo }, tipoVisitante);
        }

        // DELETE: api/TipoVisitantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVisitante(int id)
        {
            var tipoVisitante = await _context.TipoVisitantes.FindAsync(id);
            if (tipoVisitante == null)
            {
                return NotFound();
            }

            _context.TipoVisitantes.Remove(tipoVisitante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoVisitanteExists(int id)
        {
            return _context.TipoVisitantes.Any(e => e.IdTipo == id);
        }
    }
}
