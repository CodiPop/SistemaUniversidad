using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            AlumnosFacultades = new HashSet<AlumnosFacultades>();
            InscripcionesCurso = new HashSet<InscripcionesCurso>();
        }

        [Key]
        [Column("id_alumno")]
        public int IdAlumno { get; set; }
        [Column("id_documento")]
        public int IdDocumento { get; set; }
        [Column("num_documento")]
        public int NumDocumento { get; set; }
        [Required]
        [Column("nombre_alumno")]
        [StringLength(50)]
        public string NombreAlumno { get; set; }
        [Column("fecha_nacimiento", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Column("estado")]
        public int Estado { get; set; }
        [Column("facultad")]
        [StringLength(50)]
        public string Facultad { get; set; }

        [ForeignKey(nameof(IdDocumento))]
        [InverseProperty(nameof(Documento.Alumnos))]
        public virtual Documento IdDocumentoNavigation { get; set; }
        [InverseProperty("IdAlumnoNavigation")]
        public virtual ICollection<AlumnosFacultades> AlumnosFacultades { get; set; }
        [InverseProperty("IdAlumnoNavigation")]
        public virtual ICollection<InscripcionesCurso> InscripcionesCurso { get; set; }
    }
}
