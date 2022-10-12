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
    public class NivelAcademicoesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public NivelAcademicoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/NivelAcademicoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NivelAcademico>>> GetNivelAcademico()
        {
            return await _context.NivelAcademico.ToListAsync();
        }

        // GET: api/NivelAcademicoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NivelAcademico>> GetNivelAcademico(int id)
        {
            var nivelAcademico = await _context.NivelAcademico.FindAsync(id);

            if (nivelAcademico == null)
            {
                return NotFound();
            }

            return nivelAcademico;
        }

        // PUT: api/NivelAcademicoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNivelAcademico(int id, NivelAcademico nivelAcademico)
        {
            if (id != nivelAcademico.IdNivelAcademico)
            {
                return BadRequest();
            }

            _context.Entry(nivelAcademico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelAcademicoExists(id))
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

        // POST: api/NivelAcademicoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NivelAcademico>> PostNivelAcademico(NivelAcademico nivelAcademico)
        {
            _context.NivelAcademico.Add(nivelAcademico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNivelAcademico", new { id = nivelAcademico.IdNivelAcademico }, nivelAcademico);
        }

        // DELETE: api/NivelAcademicoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NivelAcademico>> DeleteNivelAcademico(int id)
        {
            var nivelAcademico = await _context.NivelAcademico.FindAsync(id);
            if (nivelAcademico == null)
            {
                return NotFound();
            }

            _context.NivelAcademico.Remove(nivelAcademico);
            await _context.SaveChangesAsync();

            return nivelAcademico;
        }

        private bool NivelAcademicoExists(int id)
        {
            return _context.NivelAcademico.Any(e => e.IdNivelAcademico == id);
        }
    }
}
