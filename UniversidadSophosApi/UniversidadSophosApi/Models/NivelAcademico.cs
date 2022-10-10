using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    [Table("Nivel_academico")]
    public partial class NivelAcademico
    {
        public NivelAcademico()
        {
            ExperienciaDocencia = new HashSet<ExperienciaDocencia>();
            TitulosAcademicos = new HashSet<TitulosAcademicos>();
        }

        [Key]
        [Column("id_nivel_academico")]
        public int IdNivelAcademico { get; set; }
        [Required]
        [Column("nombre_nivel_academico")]
        [StringLength(50)]
        public string NombreNivelAcademico { get; set; }

        [InverseProperty("IdNivelAcademicoNavigation")]
        public virtual ICollection<ExperienciaDocencia> ExperienciaDocencia { get; set; }
        [InverseProperty("IdNivelAcademicoNavigation")]
        public virtual ICollection<TitulosAcademicos> TitulosAcademicos { get; set; }
    }
}
