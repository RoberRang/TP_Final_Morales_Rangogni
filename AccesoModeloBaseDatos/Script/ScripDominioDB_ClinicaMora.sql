--DROP DATABASE ClinicaMora

USE master
GO

CREATE DATABASE ClinicaMora
GO

USE ClinicaMora
GO

CREATE TABLE [dbo].[Perfiles] (
    [IdPerfil]    INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdPerfil] ASC)
);
GO

CREATE TABLE [dbo].[Jornadas] (
    [IdJornada]   INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL,
    [Inicio]      INT          NOT NULL,
    [Fin]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdJornada])
);
ALTER TABLE [dbo].[Jornadas]
    ADD CONSTRAINT [UK_JornadaInicioFin] UNIQUE ([IdJornada],[Inicio],[Fin]);
GO

CREATE TABLE [dbo].[Especialidad] (
    [IdEspecialidad] INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    [Estado]         BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEspecialidad] ASC)
);
GO

CREATE TABLE [dbo].[Empleados] (
    [Id]           INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [IdPerfil] INT          NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [Apellido]     VARCHAR (50) NOT NULL,
    [NroDocumento] VARCHAR (10) NOT NULL,
    [FechaAlta]    DATETIME     NOT NULL,
    [IdJornada]    INT          NOT NULL,
    [Estado]       BIT          NOT NULL
);
ALTER TABLE [dbo].[Empleados]
    ADD CONSTRAINT [FK_EmpleadoPerfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[Perfiles] ([IdPerfil]);
ALTER TABLE [dbo].[Empleados]
    ADD CONSTRAINT [FK_EmpleadoIdJornada] FOREIGN KEY ([IdJornada]) REFERENCES [dbo].[Jornadas] (IdJornada);
GO

CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]  INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [UserLogin]  VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [IdEmpleado] INT          NOT NULL
);
ALTER TABLE [dbo].[Usuarios]
    ADD CONSTRAINT [FK_IdEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleados] ([Id]);
GO

CREATE TABLE [dbo].[Pacientes] (
    [IdPaciente]      INT           IDENTITY (1, 1) NOT NULL,
    [Nombres]         VARCHAR (50)  NOT NULL,
    [Apellidos]       VARCHAR (50)  NOT NULL,
    [NroDocumento]    VARCHAR (10)  NOT NULL,
    [FechaNacimiento] DATETIME      NOT NULL,
    [Sexo]            VARCHAR (20)  NULL,
    [FechaAlta]       DATETIME      NOT NULL,
    [Estado]          BIT           NOT NULL,
    [Telefono]        VARCHAR (15)  NULL,
    [Email]           VARCHAR (50)  NULL,
    [Imagen]          VARCHAR (150) NULL,
    PRIMARY KEY CLUSTERED ([IdPaciente] ASC)
);
GO

CREATE TABLE [dbo].[MedicosEspecialidad] (
    [IdMedico]       INT NOT NULL,
    [IdEspecialidad] INT NOT NULL,
    [Estado]         BIT NULL,
    PRIMARY KEY CLUSTERED ([IdMedico],[IdEspecialidad]),
    CONSTRAINT [FK_MedicoIdEspecialidad] FOREIGN KEY ([IdEspecialidad]) REFERENCES [dbo].[Especialidad] ([IdEspecialidad])
);
GO

CREATE TABLE [dbo].[SituacionTurno] (
    [IdSituacion]   INT IDENTITY (1, 1) NOT NULL,
    [Situacion]     VARCHAR (20)NOT NULL,
    [Estado]        BIT NULL,
    PRIMARY KEY CLUSTERED ([IdSituacion] ASC)
);
GO

CREATE TABLE [dbo].[Turnos] (
    [IdTurnos]			INT           IDENTITY (1, 1) NOT NULL,
    [IdMedico]			INT           NULL,
    [IdPaciente]		INT           NULL,
	[IdEspecialidad]	INT           NULL,
    [FechaReserva]		DATETIME      NOT NULL,
    [Observacion]		VARCHAR (MAX) NOT NULL,
    [IdSituacion]		INT           NULL,
    [Hora]				INT           NULL,
    PRIMARY KEY CLUSTERED ([IdTurnos] ASC),
    CONSTRAINT [FK_TurnoIdEmpleado] FOREIGN KEY ([IdMedico]) REFERENCES [dbo].[Empleados] ([Id]),
    CONSTRAINT [FK_TurnoIdPaciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Pacientes] ([IdPaciente]),
    CONSTRAINT [FK_TurnoIdEspecialidad] FOREIGN KEY ([IdEspecialidad]) REFERENCES [dbo].[Especialidad] ([IdEspecialidad]),
    CONSTRAINT [FK_TurnoIdSituacion] FOREIGN KEY ([IdSituacion]) REFERENCES [dbo].[SituacionTurno] ([IdSituacion])
);
GO

SET IDENTITY_INSERT [dbo].[Perfiles] ON
INSERT INTO [dbo].[Perfiles] ([IdPerfil], [Descripcion], [Estado]) VALUES (1, N'Administrador', 1)
INSERT INTO [dbo].[Perfiles] ([IdPerfil], [Descripcion], [Estado]) VALUES (2, N'Empleado', 1)
INSERT INTO [dbo].[Perfiles] ([IdPerfil], [Descripcion], [Estado]) VALUES (3, N'Medico', 1)
SET IDENTITY_INSERT [dbo].[Perfiles] OFF

SET IDENTITY_INSERT [dbo].[Jornadas] ON
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (1, N'Mañana 1', 1, 8, 12)
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (2, N'Tarde 1', 1, 14, 18)
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (3, N'Tarde 2', 1, 16, 20)
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (4, N'Mañana 2', 1, 9, 13)
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (5, N'Completa 1', 1, 8, 15)
INSERT INTO [dbo].[Jornadas] ([IdJornada], [Descripcion], [Estado], [Inicio], [Fin]) VALUES (6, N'Completa 2', 1, 13, 20)
SET IDENTITY_INSERT [dbo].[Jornadas] OFF

SET IDENTITY_INSERT [dbo].[SituacionTurno] ON
INSERT INTO [dbo].[SituacionTurno] ([IdSituacion], [Situacion], [Estado]) VALUES (1, 'Nuevo', 1)
INSERT INTO [dbo].[SituacionTurno] ([IdSituacion], [Situacion], [Estado]) VALUES (2, 'Reprogramado', 1)
INSERT INTO [dbo].[SituacionTurno] ([IdSituacion], [Situacion], [Estado]) VALUES (3, 'Cancelado', 1)
INSERT INTO [dbo].[SituacionTurno] ([IdSituacion], [Situacion], [Estado]) VALUES (4, 'No Asistió', 1)
INSERT INTO [dbo].[SituacionTurno] ([IdSituacion], [Situacion], [Estado]) VALUES (5, 'Cerrado', 1)
SET IDENTITY_INSERT [dbo].[SituacionTurno] OFF

SET IDENTITY_INSERT [dbo].[Empleados] ON
INSERT INTO [dbo].[Empleados] ([Id], [IdPerfil], [Nombre], [Apellido], [NroDocumento], [FechaAlta],[IdJornada], [Estado]) 
VALUES (1, 1, N'Admin', N'Admin', N'11111111', N'2000-01-01 00:00:0', 5, 1)
SET IDENTITY_INSERT [dbo].[Empleados] OFF

SET IDENTITY_INSERT [dbo].[Usuarios] ON
INSERT INTO [dbo].[Usuarios] ([IdUsuario], [UserLogin], [Password], [IdEmpleado]) 
VALUES (1, N'Admin', N'Admin', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF

SET IDENTITY_INSERT [dbo].[Especialidad] ON
INSERT INTO [dbo].[Especialidad] ([IdEspecialidad], [Descripcion], [Estado]) VALUES (1, N'Clínica', 1)
SET IDENTITY_INSERT [dbo].[Especialidad] OFF

SELECT * FROM Empleados;
SELECT * FROM Usuarios;