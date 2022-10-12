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
    public class CursosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CursosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/Cursos/5
        [HttpGet("BuscarCurso")]
        public async Task<ActionResult<Cursos>> GetCursos([FromBody] Cursos cursos)
        {
            var cursoss = await _context.Cursos.FindAsync(cursos.IdCurso);

            if (cursoss == null)
            {
                return NotFound();
            }

            return cursoss;
        }

        [HttpGet("BuscarCursoN")]
        public async Task<ActionResult<Cursos>> GetDocentesN([FromBody] Cursos cursos)
        {
            //var docentess = await _context.Docentes.FindAsync(docentes.IdDocente);
            var cursoss = await _context.Cursos.Where(x => x.NombreCurso.Contains(cursos.NombreCurso)).FirstOrDefaultAsync();

            if (cursoss == null)
            {
                return NotFound();
            }

            return cursoss;
        }


        // PUT: api/Cursos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCursos(int id, Cursos cursos)
        {
            if (id != cursos.IdCurso)
            {
                return BadRequest();
            }

            _context.Entry(cursos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CursosExists(id))
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

        // POST: api/Cursos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Insertar")]
        public async Task<ActionResult<Cursos>> PostCursos(Cursos cursos)
        {
            _context.Cursos.Add(cursos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCursos", new { id = cursos.IdCurso }, cursos);
        }

        // DELETE: api/Cursos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cursos>> DeleteCursos(int id)
        {
            var cursos = await _context.Cursos.FindAsync(id);
            if (cursos == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(cursos);
            await _context.SaveChangesAsync();

            return cursos;
        }

        private bool CursosExists(int id)
        {
            return _context.Cursos.Any(e => e.IdCurso == id);
        }
    }
}
