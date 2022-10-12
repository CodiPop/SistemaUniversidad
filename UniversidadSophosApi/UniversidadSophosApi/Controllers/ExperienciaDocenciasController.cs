using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadSophosApi.DBContext;
using UniversidadSophosApi.Data;

namespace UniversidadSophosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienciaDocenciasController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ExperienciaDocenciasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ExperienciaDocencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExperienciaDocencia>>> GetExperienciaDocencia()
        {
            return await _context.ExperienciaDocencia.ToListAsync();
        }

        // GET: api/ExperienciaDocencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExperienciaDocencia>> GetExperienciaDocencia(int id)
        {
            var experienciaDocencia = await _context.ExperienciaDocencia.FindAsync(id);

            if (experienciaDocencia == null)
            {
                return NotFound();
            }

            return experienciaDocencia;
        }

        // PUT: api/ExperienciaDocencias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExperienciaDocencia(int id, ExperienciaDocencia experienciaDocencia)
        {
            if (id != experienciaDocencia.IdExperienciaDocencia)
            {
                return BadRequest();
            }

            _context.Entry(experienciaDocencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExperienciaDocenciaExists(id))
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

        // POST: api/ExperienciaDocencias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ExperienciaDocencia>> PostExperienciaDocencia(ExperienciaDocencia experienciaDocencia)
        {
            _context.ExperienciaDocencia.Add(experienciaDocencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExperienciaDocencia", new { id = experienciaDocencia.IdExperienciaDocencia }, experienciaDocencia);
        }

        // DELETE: api/ExperienciaDocencias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ExperienciaDocencia>> DeleteExperienciaDocencia(int id)
        {
            var experienciaDocencia = await _context.ExperienciaDocencia.FindAsync(id);
            if (experienciaDocencia == null)
            {
                return NotFound();
            }

            _context.ExperienciaDocencia.Remove(experienciaDocencia);
            await _context.SaveChangesAsync();

            return experienciaDocencia;
        }

        private bool ExperienciaDocenciaExists(int id)
        {
            return _context.ExperienciaDocencia.Any(e => e.IdExperienciaDocencia == id);
        }
    }
}
