using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Data
{
    [Table("Titulos_academicos")]
    public partial class TitulosAcademicos
    {
        [Key]
        [Column("id_titulo_academico")]
        public int IdTituloAcademico { get; set; }
        [Column("id_nivel_academico")]
        public int IdNivelAcademico { get; set; }
        [Column("id_docente")]
        public int IdDocente { get; set; }

        [ForeignKey(nameof(IdDocente))]
        [InverseProperty(nameof(Docentes.TitulosAcademicos))]
        public virtual Docentes IdDocenteNavigation { get; set; }
        [ForeignKey(nameof(IdNivelAcademico))]
        [InverseProperty(nameof(NivelAcademico.TitulosAcademicos))]
        public virtual NivelAcademico IdNivelAcademicoNavigation { get; set; }
    }
}
