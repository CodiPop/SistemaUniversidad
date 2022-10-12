using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    public partial class Facultades
    {
        public Facultades()
        {
            AlumnosFacultades = new HashSet<AlumnosFacultades>();
            Cursos = new HashSet<Cursos>();
        }

        [Key]
        [Column("id_facultad")]
        public int IdFacultad { get; set; }
        [Required]
        [Column("nombre_facultad")]
        [StringLength(50)]
        public string NombreFacultad { get; set; }

        [InverseProperty("IdFacultadNavigation")]
        public virtual ICollection<AlumnosFacultades> AlumnosFacultades { get; set; }
        [InverseProperty("IdFacultadNavigation")]
        public virtual ICollection<Cursos> Cursos { get; set; }
    }
}
