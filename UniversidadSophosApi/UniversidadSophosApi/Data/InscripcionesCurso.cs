using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    [Table("Inscripciones_curso")]
    public partial class InscripcionesCurso
    {
        [Key]
        [Column("id_inscripcion")]
        public int IdInscripcion { get; set; }
        [Column("id_curso_docente")]
        public int IdCursoDocente { get; set; }
        [Column("id_alumno")]
        public int IdAlumno { get; set; }
        [ForeignKey(nameof(IdAlumno))]
        [InverseProperty(nameof(Alumnos.InscripcionesCurso))]
        public virtual Alumnos IdAlumnoNavigation { get; set; }
        [ForeignKey(nameof(IdCursoDocente))]
        [InverseProperty(nameof(CursosDocentes.InscripcionesCurso))]
        public virtual CursosDocentes IdCursoDocenteNavigation { get; set; }
    }
}
