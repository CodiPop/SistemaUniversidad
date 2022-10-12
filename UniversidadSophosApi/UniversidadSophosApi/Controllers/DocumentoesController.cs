using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversidadSophosApi.Data;
using UniversidadSophosApi.DBContext;

namespace UniversidadSophosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public DocumentoesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Documentoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento>>> GetDocumento()
        {
            return await _context.Documento.ToListAsync();
        }

        // GET: api/Documentoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Documento>> GetDocumento(int id)
        {
            var documento = await _context.Documento.FindAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            return documento;
        }

        // PUT: api/Documentoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumento(int id, Documento documento)
        {
            if (id != documento.IdDocumento)
            {
                return BadRequest();
            }

            _context.Entry(documento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id))
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

        // POST: api/Documentoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Documento>> PostDocumento(Documento documento)
        {
            _context.Documento.Add(documento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumento", new { id = documento.IdDocumento }, documento);
        }

        // DELETE: api/Documentoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Documento>> DeleteDocumento(int id)
        {
            var documento = await _context.Documento.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }

            _context.Documento.Remove(documento);
            await _context.SaveChangesAsync();

            return documento;
        }

        private bool DocumentoExists(int id)
        {
            return _context.Documento.Any(e => e.IdDocumento == id);
        }
    }
}
