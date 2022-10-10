using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    [Table("alumnos_facultades")]
    public partial class AlumnosFacultades
    {
        [Key]
        [Column("id_alumno_facultad")]
        public int IdAlumnoFacultad { get; set; }
        [Column("id_alumno")]
        public int IdAlumno { get; set; }
        [Column("id_facultad")]
        public int IdFacultad { get; set; }
        [Column("fecha_inicio", TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Column("fecha_fin", TypeName = "date")]
        public DateTime FechaFin { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey(nameof(IdAlumno))]
        [InverseProperty(nameof(Alumnos.AlumnosFacultades))]
        public virtual Alumnos IdAlumnoNavigation { get; set; }
        [ForeignKey(nameof(IdFacultad))]
        [InverseProperty(nameof(Facultades.AlumnosFacultades))]
        public virtual Facultades IdFacultadNavigation { get; set; }
    }
}
