using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    public partial class Cursos
    {
        public Cursos()
        {
            CursosDocentes = new HashSet<CursosDocentes>();
            InverseIdCursoPrerrequisitoNavigation = new HashSet<Cursos>();
        }

        [Key]
        [Column("id_curso")]
        public int IdCurso { get; set; }
        [Column("id_facultad")]
        public int IdFacultad { get; set; }
        [Required]
        [Column("nombre_curso")]
        [StringLength(50)]
        public string NombreCurso { get; set; }
        [Column("id_curso_prerrequisito")]
        public int? IdCursoPrerrequisito { get; set; }
        [Column("num_creditos")]
        public int NumCreditos { get; set; }
        [Column("cupos")]
        public int Cupos { get; set; }
        [Column("estado")]
        public int Estado { get; set; }


        [ForeignKey(nameof(IdCursoPrerrequisito))]
        [InverseProperty(nameof(Cursos.InverseIdCursoPrerrequisitoNavigation))]
        public virtual Cursos IdCursoPrerrequisitoNavigation { get; set; }
        [ForeignKey(nameof(IdFacultad))]
        [InverseProperty(nameof(Facultades.Cursos))]
        public virtual Facultades IdFacultadNavigation { get; set; }
        [InverseProperty("IdCursoNavigation")]
        public virtual ICollection<CursosDocentes> CursosDocentes { get; set; }
        [InverseProperty(nameof(Cursos.IdCursoPrerrequisitoNavigation))]
        public virtual ICollection<Cursos> InverseIdCursoPrerrequisitoNavigation { get; set; }
    }
}
