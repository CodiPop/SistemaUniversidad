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
    public class DocentesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public DocentesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Docentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docentes>>> GetDocentes()
        {
            return await _context.Docentes.ToListAsync();
        }

        // GET: api/Docentes/
        [HttpGet("{id}")]
        public async Task<ActionResult<Docentes>> GetDocentes(int id)
        {
            var docentess = await _context.Docentes.FindAsync(id);
            //var docentess = await _context.Docentes.Where(x => x.NombreDocente.Contains(docentes.NombreDocente)).FirstOrDefaultAsync();

            if (docentess == null)
            {
                return NotFound();
            }

            return docentess;
        }

        [HttpGet("BuscarDocenteN")]
        public async Task<ActionResult<Docentes>> GetDocentesN([FromBody] Docentes docentes)
        {
            //var docentess = await _context.Docentes.FindAsync(docentes.IdDocente);
            var docentess = await _context.Docentes.Where(x => x.NombreDocente.Contains(docentes.NombreDocente)).FirstOrDefaultAsync();

            if (docentess == null)
            {
                return NotFound();
            }

            return docentes;
        }

        // PUT: api/Docentes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocentes(int id, Docentes docentes)
        {
            if (id != docentes.IdDocente)
            {
                return BadRequest();
            }

            _context.Entry(docentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocentesExists(id))
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

        // POST: api/Docentes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Insertar")]
        public async Task<ActionResult<Docentes>> PostDocentes([FromBody] Docentes docentes)
        {
            _context.Docentes.Add(docentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocentes", new { id = docentes.IdDocente }, docentes);
        }

        // DELETE: api/Docentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Docentes>> DeleteDocentes(int id)
        {
            var docentes = await _context.Docentes.FindAsync(id);
            if (docentes == null)
            {
                return NotFound();
            }

            _context.Docentes.Remove(docentes);
            await _context.SaveChangesAsync();

            return docentes;
        }

        private bool DocentesExists(int id)
        {
            return _context.Docentes.Any(e => e.IdDocente == id);
        }
    }
}
