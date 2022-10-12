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
    public class AlumnosFacultadesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public AlumnosFacultadesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/AlumnosFacultades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumnosFacultades>>> GetAlumnosFacultades()
        {
            return await _context.AlumnosFacultades.ToListAsync();
        }

        // GET: api/AlumnosFacultades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumnosFacultades>> GetAlumnosFacultades(int id)
        {
            var alumnosFacultades = await _context.AlumnosFacultades.FindAsync(id);

            if (alumnosFacultades == null)
            {
                return NotFound();
            }

            return alumnosFacultades;
        }

        // PUT: api/AlumnosFacultades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumnosFacultades(int id, AlumnosFacultades alumnosFacultades)
        {
            if (id != alumnosFacultades.IdAlumnoFacultad)
            {
                return BadRequest();
            }

            _context.Entry(alumnosFacultades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnosFacultadesExists(id))
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

        // POST: api/AlumnosFacultades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlumnosFacultades>> PostAlumnosFacultades(AlumnosFacultades alumnosFacultades)
        {
            _context.AlumnosFacultades.Add(alumnosFacultades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumnosFacultades", new { id = alumnosFacultades.IdAlumnoFacultad }, alumnosFacultades);
        }

        // DELETE: api/AlumnosFacultades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlumnosFacultades>> DeleteAlumnosFacultades(int id)
        {
            var alumnosFacultades = await _context.AlumnosFacultades.FindAsync(id);
            if (alumnosFacultades == null)
            {
                return NotFound();
            }

            _context.AlumnosFacultades.Remove(alumnosFacultades);
            await _context.SaveChangesAsync();

            return alumnosFacultades;
        }

        private bool AlumnosFacultadesExists(int id)
        {
            return _context.AlumnosFacultades.Any(e => e.IdAlumnoFacultad == id);
        }
    }
}
