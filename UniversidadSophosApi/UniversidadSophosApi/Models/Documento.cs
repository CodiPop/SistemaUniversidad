using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Alumnos = new HashSet<Alumnos>();
            Docentes = new HashSet<Docentes>();
        }

        [Key]
        [Column("id_documento")]
        public int IdDocumento { get; set; }
        [Column("num_documento")]
        public int NumDocumento { get; set; }

        [InverseProperty("IdDocumentoNavigation")]
        public virtual ICollection<Alumnos> Alumnos { get; set; }
        [InverseProperty("IdDocumentoNavigation")]
        public virtual ICollection<Docentes> Docentes { get; set; }
    }
}
