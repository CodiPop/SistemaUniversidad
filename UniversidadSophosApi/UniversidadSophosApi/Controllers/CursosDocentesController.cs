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
    public class CursosDocentesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CursosDocentesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/CursosDocentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursosDocentes>>> GetCursosDocentes()
        {
            return await _context.CursosDocentes.ToListAsync();
        }

        // GET: api/CursosDocentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursosDocentes>> GetCursosDocentes(int id)
        {
            var cursosDocentes = await _context.CursosDocentes.FindAsync(id);

            if (cursosDocentes == null)
            {
                return NotFound();
            }

            return cursosDocentes;
        }

        [HttpGet("BuscarIDcs/{id}")]
        public async Task<ActionResult<CursosDocentes>> GetIdCS(int id)
        {
            var cursosDocentes = await _context.CursosDocentes.Where(p => p.IdCurso.Equals(id)).FirstAsync();

            
            if (cursosDocentes == null)
            {
                return NotFound();
            }

            return cursosDocentes;
        }
        [HttpGet("BuscarIDcsD/{id}")]
        public async Task<ActionResult<CursosDocentes>> GetIdCSD(int id)
        {
            var cursosDocentes = await _context.CursosDocentes.Where(p => p.IdDocente.Equals(id)).FirstAsync();


            if (cursosDocentes == null)
            {
                return NotFound();
            }

            return cursosDocentes;
        }
        // PUT: api/CursosDocentes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursosDocentes(int id, CursosDocentes cursosDocentes)
        {
            if (id != cursosDocentes.IdCursoDocente)
            {
                return BadRequest();
            }

            _context.Entry(cursosDocentes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosDocentesExists(id))
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

        // POST: api/CursosDocentes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CursosDocentes>> PostCursosDocentes(CursosDocentes cursosDocentes)
        {
            _context.CursosDocentes.Add(cursosDocentes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursosDocentes", new { id = cursosDocentes.IdCursoDocente }, cursosDocentes);
        }

        // DELETE: api/CursosDocentes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CursosDocentes>> DeleteCursosDocentes(int id)
        {
            var cursosDocentes = await _context.CursosDocentes.FindAsync(id);
            if (cursosDocentes == null)
            {
                return NotFound();
            }

            _context.CursosDocentes.Remove(cursosDocentes);
            await _context.SaveChangesAsync();

            return cursosDocentes;
        }


        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<IEnumerable<CursosDocentes>>> DeleteCursosDocentesBatch(int id)
        {
            // var cursosDocentes = await _context.CursosDocentes.FindAsync(id);
            var cursosDocentes = await _context.CursosDocentes.Where(x => x.IdCurso.Equals(id)).ToListAsync();
            if (cursosDocentes == null)
            {
                return NotFound();
            }

            _context.CursosDocentes.RemoveRange(cursosDocentes);
            await _context.SaveChangesAsync();

            return cursosDocentes;
        }
        private bool CursosDocentesExists(int id)
        {
            return _context.CursosDocentes.Any(e => e.IdCursoDocente == id);
        }
    }
}
