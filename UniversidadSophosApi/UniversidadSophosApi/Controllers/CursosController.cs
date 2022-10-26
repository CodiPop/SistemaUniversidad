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
        [HttpGet("{id}")]
        public async Task<ActionResult<Cursos>> GetCursos(int id)
        {
            var cursoss = await _context.Cursos.FindAsync(id);

            if (cursoss == null)
            {
                return NotFound();
            }

            return cursoss;
        }


                
        [HttpGet("InfoCursos/{idCurso}")]

        public async Task<ActionResult> GetInfoCurso(int idCurso)
        {
            // curso -> cursodocente,incripcionescurso
            var curso = _context.Cursos;
            
            // Contar
            var inscripcionescurso = _context.InscripcionesCurso;

            //cursodocente -> docente
            var cursosdocentes = _context.CursosDocentes;

            // NombreDocente
            var docentes = _context.Docentes;

            var alumnos = _context.Alumnos;

            var query = (from acumulado in (from doc in 
            (from ins in inscripcionescurso group ins by ins.IdCursoDocente into grp select new {IdCursoDocente=grp.Key, Cursando=grp.Count() }).Where(x=>x.IdCursoDocente==idCurso)
            join cursdoc in cursosdocentes on doc.IdCursoDocente equals cursdoc.IdCursoDocente select new {doc.IdCursoDocente,doc.Cursando,cursdoc.IdDocente})
            join profe in docentes on acumulado.IdDocente equals profe.IdDocente select new {acumulado.IdCursoDocente,acumulado.Cursando,profe.NombreDocente});

            var query2 = from lista in (from x in (from cur in cursosdocentes join que in query on cur.IdCursoDocente equals que.IdCursoDocente select new { cur.IdCursoDocente })
                         join inc in inscripcionescurso on x.IdCursoDocente equals inc.IdCursoDocente
                         select new { x.IdCursoDocente, inc.IdAlumno })
                         join alum in alumnos on lista.IdAlumno equals alum.IdAlumno select new { lista.IdCursoDocente,alum.NombreAlumno};
            var final = new { query, query2 };
            //var final = await(from quer in query join querty in query2 on quer.IdCursoDocente equals querty.IdCursoDocente select new { quer.IdCursoDocente, quer.NombreDocente, quer.Cursando, lista=new[] {querty} }).ToListAsync();
            return Ok(final);
        }


        [HttpGet("BuscarCursoN")]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetDocentesN([FromBody] Cursos cursos)
        {


            //var cursoss = await _context.Cursos.Where(x => x.NombreCurso.Contains(cursos.NombreCurso)).FirstOrDefaultAsync();
            var cursosss = await _context.Cursos.Where(x => x.NombreCurso.Contains(cursos.NombreCurso)).ToListAsync();

            if (cursosss == null)
            {
                return NotFound();
            }

            return cursosss;
        }

        [HttpGet("Buscar/{nombre}")]
        public async Task<ActionResult<IEnumerable<Cursos>>> GetDocentesNombre(string nombre)
        {
            var cursosss = await _context.Cursos.Where(p => p.NombreCurso.Contains(nombre)).ToListAsync();

            //var cursoss = await _context.Cursos.Where(x => x.NombreCurso.Contains(cursos.NombreCurso)).FirstOrDefaultAsync();
            //var cursosss = await _context.Cursos.Where(x => x.NombreCurso.Contains(cursos.NombreCurso)).ToListAsync();
            if (cursosss == null)
            {
                return NotFound();
            }

            return cursosss;
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
