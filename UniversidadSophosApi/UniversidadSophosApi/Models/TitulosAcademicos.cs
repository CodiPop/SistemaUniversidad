using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    [Table("Titulos_academicos")]
    public partial class TitulosAcademicos
    {
        public TitulosAcademicos()
        {
            Docentes = new HashSet<Docentes>();
        }

        [Key]
        [Column("id_titulo_academico")]
        public int IdTituloAcademico { get; set; }
        [Column("id_docente")]
        public int IdDocente { get; set; }
        [Column("id_nivel_academico")]
        public int IdNivelAcademico { get; set; }
        [Required]
        [Column("nivel_academico")]
        [StringLength(50)]
        public string NivelAcademico { get; set; }

        [ForeignKey(nameof(IdDocente))]
        [InverseProperty("TitulosAcademicos")]
        public virtual Docentes IdDocenteNavigation { get; set; }
        [ForeignKey(nameof(IdNivelAcademico))]
        [InverseProperty("TitulosAcademicos")]
        public virtual NivelAcademico IdNivelAcademicoNavigation { get; set; }
        [InverseProperty("IdTituloNavigation")]
        public virtual ICollection<Docentes> Docentes { get; set; }
    }
}
