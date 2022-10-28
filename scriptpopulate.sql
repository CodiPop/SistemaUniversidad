USE [master]
GO
/****** Object:  Database [UniversidadSophos]    Script Date: 28/10/2022 1:20:09 a. m. ******/
CREATE DATABASE [UniversidadSophos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversidadSophos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversidadSophos.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'UniversidadSophos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\UniversidadSophos_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [UniversidadSophos] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversidadSophos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversidadSophos] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversidadSophos] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversidadSophos] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversidadSophos] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversidadSophos] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversidadSophos] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversidadSophos] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversidadSophos] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversidadSophos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversidadSophos] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversidadSophos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversidadSophos] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversidadSophos] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversidadSophos] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversidadSophos] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversidadSophos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversidadSophos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversidadSophos] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversidadSophos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversidadSophos] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversidadSophos] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversidadSophos] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversidadSophos] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversidadSophos] SET  MULTI_USER 
GO
ALTER DATABASE [UniversidadSophos] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversidadSophos] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversidadSophos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversidadSophos] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [UniversidadSophos] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [UniversidadSophos] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [UniversidadSophos] SET QUERY_STORE = OFF
GO
USE [UniversidadSophos]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[id_alumno] [int] IDENTITY(1,1) NOT NULL,
	[id_documento] [int] NOT NULL,
	[num_documento] [int] NOT NULL,
	[nombre_alumno] [nvarchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[estado] [int] NOT NULL,
	[facultad] [nvarchar](50) NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[id_alumno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[alumnos_facultades]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[alumnos_facultades](
	[id_alumno_facultad] [int] IDENTITY(1,1) NOT NULL,
	[id_alumno] [int] NOT NULL,
	[id_facultad] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK_alumnos_facultades] PRIMARY KEY CLUSTERED 
(
	[id_alumno_facultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[id_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_facultad] [int] NOT NULL,
	[nombre_curso] [nvarchar](50) NOT NULL,
	[id_curso_prerrequisito] [int] NULL,
	[num_creditos] [int] NOT NULL,
	[cupos] [int] NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Cursos] PRIMARY KEY CLUSTERED 
(
	[id_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cursos_docentes]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cursos_docentes](
	[id_curso_docente] [int] IDENTITY(1,1) NOT NULL,
	[id_curso] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
	[nombre_curso] [nvarchar](50) NOT NULL,
	[cupo_salon] [int] NOT NULL,
 CONSTRAINT [PK_cursos_docentes] PRIMARY KEY CLUSTERED 
(
	[id_curso_docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docentes]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docentes](
	[id_docente] [int] IDENTITY(1,1) NOT NULL,
	[id_documento] [int] NOT NULL,
	[num_documento] [int] NOT NULL,
	[nombre_docente] [nvarchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[estado] [int] NOT NULL,
	[nombre_nivel_academico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Docentes] PRIMARY KEY CLUSTERED 
(
	[id_docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[id_documento] [int] IDENTITY(1,1) NOT NULL,
	[num_documento] [int] NOT NULL,
 CONSTRAINT [PK_Documento] PRIMARY KEY CLUSTERED 
(
	[id_documento] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Experiencia_docencia]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiencia_docencia](
	[id_experiencia_docencia] [int] IDENTITY(1,1) NOT NULL,
	[id_docente] [int] NOT NULL,
	[fecha_inicio] [date] NOT NULL,
	[fecha_fin] [date] NOT NULL,
 CONSTRAINT [PK_Experiencia_docencia] PRIMARY KEY CLUSTERED 
(
	[id_experiencia_docencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultades]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultades](
	[id_facultad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_facultad] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Facultades] PRIMARY KEY CLUSTERED 
(
	[id_facultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inscripciones_curso]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inscripciones_curso](
	[id_inscripcion] [int] IDENTITY(1,1) NOT NULL,
	[id_curso_docente] [int] NOT NULL,
	[id_alumno] [int] NOT NULL,
 CONSTRAINT [PK_Inscripciones_curso] PRIMARY KEY CLUSTERED 
(
	[id_inscripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nivel_academico]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nivel_academico](
	[id_nivel_academico] [int] IDENTITY(1,1) NOT NULL,
	[nombre_nivel_academico] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Nivel_academico] PRIMARY KEY CLUSTERED 
(
	[id_nivel_academico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Titulos_academicos]    Script Date: 28/10/2022 1:20:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titulos_academicos](
	[id_titulo_academico] [int] IDENTITY(1,1) NOT NULL,
	[id_nivel_academico] [int] NOT NULL,
	[id_docente] [int] NOT NULL,
 CONSTRAINT [PK_Titulos_academicos] PRIMARY KEY CLUSTERED 
(
	[id_titulo_academico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Documento] FOREIGN KEY([id_documento])
REFERENCES [dbo].[Documento] ([id_documento])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Documento]
GO
ALTER TABLE [dbo].[alumnos_facultades]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_facultades_Alumnos] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[Alumnos] ([id_alumno])
GO
ALTER TABLE [dbo].[alumnos_facultades] CHECK CONSTRAINT [FK_alumnos_facultades_Alumnos]
GO
ALTER TABLE [dbo].[alumnos_facultades]  WITH CHECK ADD  CONSTRAINT [FK_alumnos_facultades_Facultades] FOREIGN KEY([id_facultad])
REFERENCES [dbo].[Facultades] ([id_facultad])
GO
ALTER TABLE [dbo].[alumnos_facultades] CHECK CONSTRAINT [FK_alumnos_facultades_Facultades]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Cursos] FOREIGN KEY([id_curso_prerrequisito])
REFERENCES [dbo].[Cursos] ([id_curso])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Cursos]
GO
ALTER TABLE [dbo].[Cursos]  WITH CHECK ADD  CONSTRAINT [FK_Cursos_Facultades] FOREIGN KEY([id_facultad])
REFERENCES [dbo].[Facultades] ([id_facultad])
GO
ALTER TABLE [dbo].[Cursos] CHECK CONSTRAINT [FK_Cursos_Facultades]
GO
ALTER TABLE [dbo].[cursos_docentes]  WITH CHECK ADD  CONSTRAINT [FK_cursos_docentes_Cursos] FOREIGN KEY([id_curso])
REFERENCES [dbo].[Cursos] ([id_curso])
GO
ALTER TABLE [dbo].[cursos_docentes] CHECK CONSTRAINT [FK_cursos_docentes_Cursos]
GO
ALTER TABLE [dbo].[cursos_docentes]  WITH CHECK ADD  CONSTRAINT [FK_cursos_docentes_Docentes] FOREIGN KEY([id_docente])
REFERENCES [dbo].[Docentes] ([id_docente])
GO
ALTER TABLE [dbo].[cursos_docentes] CHECK CONSTRAINT [FK_cursos_docentes_Docentes]
GO
ALTER TABLE [dbo].[Docentes]  WITH CHECK ADD  CONSTRAINT [FK_Docentes_Documento] FOREIGN KEY([id_documento])
REFERENCES [dbo].[Documento] ([id_documento])
GO
ALTER TABLE [dbo].[Docentes] CHECK CONSTRAINT [FK_Docentes_Documento]
GO
ALTER TABLE [dbo].[Experiencia_docencia]  WITH CHECK ADD  CONSTRAINT [FK_Experiencia_docencia_Docentes] FOREIGN KEY([id_docente])
REFERENCES [dbo].[Docentes] ([id_docente])
GO
ALTER TABLE [dbo].[Experiencia_docencia] CHECK CONSTRAINT [FK_Experiencia_docencia_Docentes]
GO
ALTER TABLE [dbo].[Inscripciones_curso]  WITH CHECK ADD  CONSTRAINT [FK_Inscripciones_curso_Alumnos] FOREIGN KEY([id_alumno])
REFERENCES [dbo].[Alumnos] ([id_alumno])
GO
ALTER TABLE [dbo].[Inscripciones_curso] CHECK CONSTRAINT [FK_Inscripciones_curso_Alumnos]
GO
ALTER TABLE [dbo].[Inscripciones_curso]  WITH CHECK ADD  CONSTRAINT [FK_Inscripciones_curso_cursos_docentes] FOREIGN KEY([id_curso_docente])
REFERENCES [dbo].[cursos_docentes] ([id_curso_docente])
GO
ALTER TABLE [dbo].[Inscripciones_curso] CHECK CONSTRAINT [FK_Inscripciones_curso_cursos_docentes]
GO
ALTER TABLE [dbo].[Titulos_academicos]  WITH CHECK ADD  CONSTRAINT [FK_Titulos_academicos_Docentes] FOREIGN KEY([id_docente])
REFERENCES [dbo].[Docentes] ([id_docente])
GO
ALTER TABLE [dbo].[Titulos_academicos] CHECK CONSTRAINT [FK_Titulos_academicos_Docentes]
GO
ALTER TABLE [dbo].[Titulos_academicos]  WITH CHECK ADD  CONSTRAINT [FK_Titulos_academicos_Nivel_academico] FOREIGN KEY([id_nivel_academico])
REFERENCES [dbo].[Nivel_academico] ([id_nivel_academico])
GO
ALTER TABLE [dbo].[Titulos_academicos] CHECK CONSTRAINT [FK_Titulos_academicos_Nivel_academico]
GO
USE [master]
GO
ALTER DATABASE [UniversidadSophos] SET  READ_WRITE 
GO
