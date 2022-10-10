using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    [Table("Experiencia_docencia")]
    public partial class ExperienciaDocencia
    {
        [Key]
        [Column("id_experiencia_docencia")]
        public int IdExperienciaDocencia { get; set; }
        [Column("id_docente")]
        public int IdDocente { get; set; }
        [Column("id_nivel_academico")]
        public int IdNivelAcademico { get; set; }
        [Column("fecha_inicio", TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Column("fecha_fin", TypeName = "date")]
        public DateTime FechaFin { get; set; }

        [ForeignKey(nameof(IdDocente))]
        [InverseProperty(nameof(Docentes.ExperienciaDocencia))]
        public virtual Docentes IdDocenteNavigation { get; set; }
        [ForeignKey(nameof(IdNivelAcademico))]
        [InverseProperty(nameof(NivelAcademico.ExperienciaDocencia))]
        public virtual NivelAcademico IdNivelAcademicoNavigation { get; set; }
    }
}
