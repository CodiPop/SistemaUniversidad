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
    public class InscripcionesCursoesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public InscripcionesCursoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/InscripcionesCursoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscripcionesCurso>>> GetInscripcionesCurso()
        {
            return await _context.InscripcionesCurso.ToListAsync();
        }

        // GET: api/InscripcionesCursoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionesCurso>> GetInscripcionesCurso(int id)
        {
            var inscripcionesCurso = await _context.InscripcionesCurso.FindAsync(id);

            if (inscripcionesCurso == null)
            {
                return NotFound();
            }

            return inscripcionesCurso;
        }

        // PUT: api/InscripcionesCursoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcionesCurso(int id, InscripcionesCurso inscripcionesCurso)
        {
            if (id != inscripcionesCurso.IdInscripcion)
            {
                return BadRequest();
            }

            _context.Entry(inscripcionesCurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionesCursoExists(id))
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

        // POST: api/InscripcionesCursoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<InscripcionesCurso>> PostInscripcionesCurso(InscripcionesCurso inscripcionesCurso)
        {
            _context.InscripcionesCurso.Add(inscripcionesCurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripcionesCurso", new { id = inscripcionesCurso.IdInscripcion }, inscripcionesCurso);
        }

        // DELETE: api/InscripcionesCursoes/5
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<InscripcionesCurso>>> DeleteInscripcionesCurso(int id)
        {
            //var inscripcionesCurso = await _context.InscripcionesCurso.FindAsync(id);
            var inscripcionesCurso = await _context.InscripcionesCurso.Where(x => x.IdAlumno.Equals(id)).ToListAsync();
            if (inscripcionesCurso == null)
            {
                return NotFound();
            }

            _context.InscripcionesCurso.RemoveRange(inscripcionesCurso);
            await _context.SaveChangesAsync();

            return inscripcionesCurso;
        }

        [HttpDelete("deleteCD/{id}")]
        public async Task<ActionResult<IEnumerable<InscripcionesCurso>>> DeleteInscripcionesCursoCD(int id)
        {
            
            var inscripcionesCurso = await _context.InscripcionesCurso.Where(x => x.IdCursoDocente.Equals(id)).ToListAsync();
            if (inscripcionesCurso == null)
            {
                return NotFound();
            }

            _context.InscripcionesCurso.RemoveRange(inscripcionesCurso);
            await _context.SaveChangesAsync();

            return inscripcionesCurso;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InscripcionesCurso>> DeleteInscripcionesCursoA(int id)
        {
            var inscripcionesCurso = await _context.InscripcionesCurso.FindAsync(id);
            if (inscripcionesCurso == null)
            {
                return NotFound();
            }

            _context.InscripcionesCurso.Remove(inscripcionesCurso);
            await _context.SaveChangesAsync();

            return inscripcionesCurso;
        }
        private bool InscripcionesCursoExists(int id)
        {
            return _context.InscripcionesCurso.Any(e => e.IdInscripcion == id);
        }
    }
}
