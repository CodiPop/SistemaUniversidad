using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    [Table("cursos_docentes")]
    public partial class CursosDocentes
    {
        public CursosDocentes()
        {
            InscripcionesCurso = new HashSet<InscripcionesCurso>();
        }

        [Key]
        [Column("id_curso_docente")]
        public int IdCursoDocente { get; set; }
        [Column("id_curso")]
        public int IdCurso { get; set; }
        [Column("id_docente")]
        public int IdDocente { get; set; }
        [Required]
        [Column("nombre_curso")]
        [StringLength(50)]
        public string NombreCurso { get; set; }
        [Column("cupo_salon")]
        public int CupoSalon { get; set; }

        [ForeignKey(nameof(IdCurso))]
        [InverseProperty(nameof(Cursos.CursosDocentes))]
        public virtual Cursos IdCursoNavigation { get; set; }
        [ForeignKey(nameof(IdDocente))]
        [InverseProperty(nameof(Docentes.CursosDocentes))]
        public virtual Docentes IdDocenteNavigation { get; set; }
        [InverseProperty("IdCursoDocenteNavigation")]
        public virtual ICollection<InscripcionesCurso> InscripcionesCurso { get; set; }
    }
}
