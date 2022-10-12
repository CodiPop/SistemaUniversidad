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
    public class TitulosAcademicosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public TitulosAcademicosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/TitulosAcademicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TitulosAcademicos>>> GetTitulosAcademicos()
        {
            return await _context.TitulosAcademicos.ToListAsync();
        }

        // GET: api/TitulosAcademicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitulosAcademicos>> GetTitulosAcademicos(int id)
        {
            var titulosAcademicos = await _context.TitulosAcademicos.FindAsync(id);

            if (titulosAcademicos == null)
            {
                return NotFound();
            }

            return titulosAcademicos;
        }

        // PUT: api/TitulosAcademicos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitulosAcademicos(int id, TitulosAcademicos titulosAcademicos)
        {
            if (id != titulosAcademicos.IdTituloAcademico)
            {
                return BadRequest();
            }

            _context.Entry(titulosAcademicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitulosAcademicosExists(id))
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

        // POST: api/TitulosAcademicos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TitulosAcademicos>> PostTitulosAcademicos(TitulosAcademicos titulosAcademicos)
        {
            _context.TitulosAcademicos.Add(titulosAcademicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitulosAcademicos", new { id = titulosAcademicos.IdTituloAcademico }, titulosAcademicos);
        }

        // DELETE: api/TitulosAcademicos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TitulosAcademicos>> DeleteTitulosAcademicos(int id)
        {
            var titulosAcademicos = await _context.TitulosAcademicos.FindAsync(id);
            if (titulosAcademicos == null)
            {
                return NotFound();
            }

            _context.TitulosAcademicos.Remove(titulosAcademicos);
            await _context.SaveChangesAsync();

            return titulosAcademicos;
        }

        private bool TitulosAcademicosExists(int id)
        {
            return _context.TitulosAcademicos.Any(e => e.IdTituloAcademico == id);
        }
    }
}
