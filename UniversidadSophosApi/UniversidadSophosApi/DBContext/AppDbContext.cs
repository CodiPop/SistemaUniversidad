using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UniversidadSophosApi.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace UniversidadSophosApi.DBContext
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<AlumnosFacultades> AlumnosFacultades { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<CursosDocentes> CursosDocentes { get; set; }
        public virtual DbSet<Docentes> Docentes { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<ExperienciaDocencia> ExperienciaDocencia { get; set; }
        public virtual DbSet<Facultades> Facultades { get; set; }
        public virtual DbSet<InscripcionesCurso> InscripcionesCurso { get; set; }
        public virtual DbSet<NivelAcademico> NivelAcademico { get; set; }
        public virtual DbSet<TitulosAcademicos> TitulosAcademicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-TP2BN5N\\SQLEXPRESS;Initial Catalog=UniversidadSophos;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumnos_Documento");
            });

            modelBuilder.Entity<AlumnosFacultades>(entity =>
            {
                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.AlumnosFacultades)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alumnos_facultades_Alumnos");

                entity.HasOne(d => d.IdFacultadNavigation)
                    .WithMany(p => p.AlumnosFacultades)
                    .HasForeignKey(d => d.IdFacultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alumnos_facultades_Facultades");
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasOne(d => d.IdCursoPrerrequisitoNavigation)
                    .WithMany(p => p.InverseIdCursoPrerrequisitoNavigation)
                    .HasForeignKey(d => d.IdCursoPrerrequisito)
                    .HasConstraintName("FK_Cursos_Cursos");

                entity.HasOne(d => d.IdFacultadNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdFacultad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_Facultades");
            });

            modelBuilder.Entity<CursosDocentes>(entity =>
            {
                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CursosDocentes)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_docentes_Cursos");

                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.CursosDocentes)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cursos_docentes_Docentes");
            });

            modelBuilder.Entity<Docentes>(entity =>
            {
                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.Docentes)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Docentes_Documento");

                entity.HasOne(d => d.IdTituloNavigation)
                    .WithMany(p => p.Docentes)
                    .HasForeignKey(d => d.IdTitulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Docentes_Titulos_academicos");
            });

            modelBuilder.Entity<ExperienciaDocencia>(entity =>
            {
                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.ExperienciaDocencia)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Experiencia_docencia_Docentes");

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.ExperienciaDocencia)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Experiencia_docencia_Nivel_academico");
            });

            modelBuilder.Entity<InscripcionesCurso>(entity =>
            {
                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.InscripcionesCurso)
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_curso_Alumnos");

                entity.HasOne(d => d.IdCursoDocenteNavigation)
                    .WithMany(p => p.InscripcionesCurso)
                    .HasForeignKey(d => d.IdCursoDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inscripciones_curso_cursos_docentes");
            });

            modelBuilder.Entity<TitulosAcademicos>(entity =>
            {
                entity.HasOne(d => d.IdDocenteNavigation)
                    .WithMany(p => p.TitulosAcademicos)
                    .HasForeignKey(d => d.IdDocente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Titulos_academicos_Docentes");

                entity.HasOne(d => d.IdNivelAcademicoNavigation)
                    .WithMany(p => p.TitulosAcademicos)
                    .HasForeignKey(d => d.IdNivelAcademico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Titulos_academicos_Nivel_academico");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
