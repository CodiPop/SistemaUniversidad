using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadSophosApi.DBContext;
using UniversidadSophosApi.Models;

namespace UniversidadSophosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlumnosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Alumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumnos>>> GetAlumnos()
        {
            return await _context.Alumnos.ToListAsync();
        }

        //Busqueda por Id de alumno
        // GET: api/Alumnos/BuscarAlumno
        [HttpGet("BuscarAlumno")]
        public async Task<ActionResult<Alumnos>> GetAlumnos([FromBody] Alumnos alumnos)
        {
            var alumnoss = await _context.Alumnos.FindAsync(alumnos.IdAlumno);

            if (alumnoss == null)
            {
                return NotFound();
            }

            return alumnoss;
        }


        //Busqueda por Nombre de alumno
        // GET: api/Alumnos/BuscarAlumnoN
        [HttpGet("BuscarAlumnoN")]
        public async Task<ActionResult<Alumnos>> GetAlumnosN([FromBody] Alumnos alumnos)
        {
            //var alumnoss = await _context.Alumnos.FindAsync(alumnos.NombreAlumno);
            var alumnoss = await _context.Alumnos.Where(x => x.NombreAlumno.Contains(alumnos.NombreAlumno)).FirstOrDefaultAsync();

            if (alumnoss == null)
            {
                return NotFound();
            }

            return alumnoss;
        }

        // PUT: api/Alumnos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnos(int id, Alumnos alumnos)
        {
            if (id != alumnos.IdAlumno)
            {
                return BadRequest();
            }

            _context.Entry(alumnos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnosExists(id))
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

        // POST: api/Alumnos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("Insertar")]
        public async Task<ActionResult<Alumnos>> PostAlumnos([FromBody] Alumnos alumnos)
        {
            _context.Alumnos.Add(alumnos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnos", new { id = alumnos.IdAlumno }, alumnos);
        }

        // DELETE: api/Alumnos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Alumnos>> DeleteAlumnos(int id)
        {
            var alumnos = await _context.Alumnos.FindAsync(id);
            if (alumnos == null)
            {
                return NotFound();
            }

            _context.Alumnos.Remove(alumnos);
            await _context.SaveChangesAsync();

            return alumnos;
        }

        private bool AlumnosExists(int id)
        {
            return _context.Alumnos.Any(e => e.IdAlumno == id);
        }
    }
}
