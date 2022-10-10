using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    public partial class Docentes
    {
        public Docentes()
        {
            CursosDocentes = new HashSet<CursosDocentes>();
            ExperienciaDocencia = new HashSet<ExperienciaDocencia>();
            TitulosAcademicos = new HashSet<TitulosAcademicos>();
        }

        [Key]
        [Column("id_docente")]
        public int IdDocente { get; set; }
        [Column("id_titulo")]
        public int IdTitulo { get; set; }
        [Column("id_documento")]
        public int IdDocumento { get; set; }
        [Required]
        [Column("num_documento")]
        [StringLength(50)]
        public string NumDocumento { get; set; }
        [Required]
        [Column("nombre_docente")]
        [StringLength(50)]
        public string NombreDocente { get; set; }
        [Column("fecha_nacimiento", TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Column("estado")]
        public bool Estado { get; set; }

        [ForeignKey(nameof(IdDocumento))]
        [InverseProperty(nameof(Documento.Docentes))]
        public virtual Documento IdDocumentoNavigation { get; set; }
        [ForeignKey(nameof(IdTitulo))]
        [InverseProperty("Docentes")]
        public virtual TitulosAcademicos IdTituloNavigation { get; set; }
        [InverseProperty("IdDocenteNavigation")]
        public virtual ICollection<CursosDocentes> CursosDocentes { get; set; }
        [InverseProperty("IdDocenteNavigation")]
        public virtual ICollection<ExperienciaDocencia> ExperienciaDocencia { get; set; }
        [InverseProperty("IdDocenteNavigation")]
        public virtual ICollection<TitulosAcademicos> TitulosAcademicos { get; set; }
    }
}
