USE [master]
GO
/****** Object:  Database [UniversidadSophos]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Alumnos]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[alumnos_facultades]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Cursos]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[cursos_docentes]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Docentes]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Documento]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Experiencia_docencia]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Facultades]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Inscripciones_curso]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Nivel_academico]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
/****** Object:  Table [dbo].[Titulos_academicos]    Script Date: 30/10/2022 7:00:25 p. m. ******/
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
SET IDENTITY_INSERT [dbo].[Alumnos] ON 

INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (1020, 1, 1004347740, N'Santiago Alberto Guerrero Martinez', CAST(N'0200-05-02' AS Date), 1, N'Ingenieria de Sistemas')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (1031, 7, 15675642, N'Camelo de Jesus', CAST(N'2000-02-05' AS Date), 1, N'Ingenieria de Sistemas')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2020, 8, 85264578, N'Angela Morales Cervantes', CAST(N'1980-01-05' AS Date), 1, N'Diseño')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2022, 9, 1587956, N'Johan Mendez', CAST(N'2001-06-10' AS Date), 1, N'Ingenieria Industrial')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2025, 10, 789123489, N'Loki Guerrero Martinez', CAST(N'1999-02-01' AS Date), 1, N'Matematicas')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2026, 11, 25942, N'Samuel Belen', CAST(N'1998-03-11' AS Date), 1, N'Filosofia')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2027, 12, 564923, N'Andres Esteban', CAST(N'2005-03-11' AS Date), 1, N'Diseño')
INSERT [dbo].[Alumnos] ([id_alumno], [id_documento], [num_documento], [nombre_alumno], [fecha_nacimiento], [estado], [facultad]) VALUES (2028, 13, 125525, N'Samir Luis', CAST(N'2006-08-28' AS Date), 1, N'Filosofia')
SET IDENTITY_INSERT [dbo].[Alumnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Cursos] ON 

INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (1, 1, N'Animacion', 5, 3, 20, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2, 1, N'Programacion Orientada a Objetos', 5, 4, 25, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (5, 5, N'Introduccion', NULL, 0, 100, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2006, 1, N'Matematicas', 5, 3, 20, N'0')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2007, 5, N'Calculo 1', 2006, 5, 105, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2008, 5, N'Introduccion a la filosofia', 5, 2, 59, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2009, 5, N'Fisica Mecanica', 2006, 3, 60, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2010, 5, N'Fisica Cuantica', 2009, 7, 20, N'0')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2013, 1, N'Bases de datos', 5, 3, 15, N'1')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2014, 2, N'Calculo 3D', 5, 3, 20, N'0')
INSERT [dbo].[Cursos] ([id_curso], [id_facultad], [nombre_curso], [id_curso_prerrequisito], [num_creditos], [cupos], [estado]) VALUES (2019, 5, N' el curso peye', 5, 0, 105, N'1')
SET IDENTITY_INSERT [dbo].[Cursos] OFF
GO
SET IDENTITY_INSERT [dbo].[cursos_docentes] ON 

INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (1, 1, 1, N'Animacion', 25)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (2, 2, 3, N'Programacion Orientada a Objetos', 30)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (4, 2007, 2, N'Calculo 1', 20)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (5, 5, 1008, N'Introduccion', 100)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (8, 2008, 1009, N'Introduccion a la filosofia', 50)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (9, 2006, 1, N'Matematicas', 20)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (10, 2009, 3, N'Fisica mecnica', 30)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (11, 2010, 1009, N'Fisica Cuantica', 20)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (12, 2013, 1008, N'Bases de datos', 30)
INSERT [dbo].[cursos_docentes] ([id_curso_docente], [id_curso], [id_docente], [nombre_curso], [cupo_salon]) VALUES (13, 2014, 2, N'Calculo 3D', 10)
SET IDENTITY_INSERT [dbo].[cursos_docentes] OFF
GO
SET IDENTITY_INSERT [dbo].[Docentes] ON 

INSERT [dbo].[Docentes] ([id_docente], [id_documento], [num_documento], [nombre_docente], [fecha_nacimiento], [estado], [nombre_nivel_academico]) VALUES (1, 2, 12552558, N'Alberto Guerrero Henriquez', CAST(N'1980-01-05' AS Date), 1, N'Doctor')
INSERT [dbo].[Docentes] ([id_docente], [id_documento], [num_documento], [nombre_docente], [fecha_nacimiento], [estado], [nombre_nivel_academico]) VALUES (2, 6, 8526457, N'Enfren Rodriguez', CAST(N'1999-10-21' AS Date), 1, N'Practicante')
INSERT [dbo].[Docentes] ([id_docente], [id_documento], [num_documento], [nombre_docente], [fecha_nacimiento], [estado], [nombre_nivel_academico]) VALUES (3, 7, 789456, N'Marcos Maestres', CAST(N'1987-09-21' AS Date), 1, N'Magister')
INSERT [dbo].[Docentes] ([id_docente], [id_documento], [num_documento], [nombre_docente], [fecha_nacimiento], [estado], [nombre_nivel_academico]) VALUES (1008, 14, 36693818, N'Luis Ortega', CAST(N'1960-02-01' AS Date), 1, N'Doctor')
INSERT [dbo].[Docentes] ([id_docente], [id_documento], [num_documento], [nombre_docente], [fecha_nacimiento], [estado], [nombre_nivel_academico]) VALUES (1009, 15, 784512369, N'Pablo Emilio', CAST(N'1985-06-18' AS Date), 1, N'Magister')
SET IDENTITY_INSERT [dbo].[Docentes] OFF
GO
SET IDENTITY_INSERT [dbo].[Documento] ON 

INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (1, 1004347740)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (2, 12552558)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (4, 147852369)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (5, 369852741)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (6, 8526457)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (7, 789456124)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (8, 1587956)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (9, 256723)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (10, 789123489)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (11, 25942)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (12, 564923)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (13, 125525)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (14, 36693818)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (15, 784512369)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (16, 1575560)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (17, 258)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (18, 12057)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (19, 1879)
INSERT [dbo].[Documento] ([id_documento], [num_documento]) VALUES (20, 541589)
SET IDENTITY_INSERT [dbo].[Documento] OFF
GO
SET IDENTITY_INSERT [dbo].[Experiencia_docencia] ON 

INSERT [dbo].[Experiencia_docencia] ([id_experiencia_docencia], [id_docente], [fecha_inicio], [fecha_fin]) VALUES (1, 1, CAST(N'2015-05-06' AS Date), CAST(N'2020-06-10' AS Date))
INSERT [dbo].[Experiencia_docencia] ([id_experiencia_docencia], [id_docente], [fecha_inicio], [fecha_fin]) VALUES (2, 2, CAST(N'2019-08-19' AS Date), CAST(N'2021-11-10' AS Date))
SET IDENTITY_INSERT [dbo].[Experiencia_docencia] OFF
GO
SET IDENTITY_INSERT [dbo].[Facultades] ON 

INSERT [dbo].[Facultades] ([id_facultad], [nombre_facultad]) VALUES (1, N'Ingenieria de Sistemas')
INSERT [dbo].[Facultades] ([id_facultad], [nombre_facultad]) VALUES (2, N'Diseño Grafico')
INSERT [dbo].[Facultades] ([id_facultad], [nombre_facultad]) VALUES (3, N'Derecho')
INSERT [dbo].[Facultades] ([id_facultad], [nombre_facultad]) VALUES (4, N'Matematicas')
INSERT [dbo].[Facultades] ([id_facultad], [nombre_facultad]) VALUES (5, N'General')
SET IDENTITY_INSERT [dbo].[Facultades] OFF
GO
SET IDENTITY_INSERT [dbo].[Inscripciones_curso] ON 

INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (4, 1, 2020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (6, 2, 1020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (7, 2, 1031)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (8, 4, 2022)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (9, 4, 2020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (10, 4, 1031)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (11, 5, 2020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (12, 5, 1020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (18, 8, 1031)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (19, 8, 1020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (23, 10, 2020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (25, 9, 1020)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (26, 11, 2028)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (27, 12, 2028)
INSERT [dbo].[Inscripciones_curso] ([id_inscripcion], [id_curso_docente], [id_alumno]) VALUES (29, 13, 1031)
SET IDENTITY_INSERT [dbo].[Inscripciones_curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Nivel_academico] ON 

INSERT [dbo].[Nivel_academico] ([id_nivel_academico], [nombre_nivel_academico]) VALUES (1, N'Doctor@')
INSERT [dbo].[Nivel_academico] ([id_nivel_academico], [nombre_nivel_academico]) VALUES (2, N'Magister')
INSERT [dbo].[Nivel_academico] ([id_nivel_academico], [nombre_nivel_academico]) VALUES (3, N'Licenciad@')
INSERT [dbo].[Nivel_academico] ([id_nivel_academico], [nombre_nivel_academico]) VALUES (4, N'Practicante')
SET IDENTITY_INSERT [dbo].[Nivel_academico] OFF
GO
SET IDENTITY_INSERT [dbo].[Titulos_academicos] ON 

INSERT [dbo].[Titulos_academicos] ([id_titulo_academico], [id_nivel_academico], [id_docente]) VALUES (1, 2, 1)
INSERT [dbo].[Titulos_academicos] ([id_titulo_academico], [id_nivel_academico], [id_docente]) VALUES (2, 2, 3)
SET IDENTITY_INSERT [dbo].[Titulos_academicos] OFF
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
