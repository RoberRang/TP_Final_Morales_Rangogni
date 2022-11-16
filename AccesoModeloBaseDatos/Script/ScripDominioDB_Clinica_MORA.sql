CREATE DATABASE Clinica_MORA

USE Clinica_MORA

CREATE TABLE [dbo].[Especialidad] (
    [IdEspecialidad] INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    [Estado]         BIT          NOT NULL
);

CREATE TABLE [dbo].[TipoPerfil] (
    [IdPerfil]    INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL
);

CREATE TABLE [dbo].[JornadaTurno] (
    [IdJornada]   INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL,
    [Inicio]      INT          NOT NULL,
    [Fin]         INT          NOT NULL
);

CREATE TABLE [dbo].[Empleados] (
    [Id]           INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [IdTipoPerfil] INT          NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [Apellido]     VARCHAR (50) NOT NULL,
    [NroDocumento] VARCHAR (10) NOT NULL,
    [FechaAlta]    DATETIME     NOT NULL,
    [Estado]       BIT          NOT NULL
);
ALTER TABLE [dbo].[Empleados]
    ADD CONSTRAINT [FK_TipoPerfil] FOREIGN KEY ([IdTipoPerfil]) REFERENCES [dbo].[TipoPerfil] ([IdPerfil]);


CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]  INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [UserLogin]  VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [IdEmpleado] INT          NOT NULL
);
ALTER TABLE [dbo].[Usuarios]
    ADD CONSTRAINT [FK_IdEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleados] ([Id]);

CREATE TABLE [dbo].[Pacientes] (
    [IdPaciente]      INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Nombres]         VARCHAR (50)  NOT NULL,
    [Apellidos]       VARCHAR (50)  NOT NULL,
    [NroDocumento]    VARCHAR (10)  NOT NULL,
    [FechaNacimiento] DATETIME      NOT NULL,
    [Sexo]            VARCHAR (20)  NULL,
    [FechaAlta]       DATETIME      NOT NULL,
    [Estado]          BIT           NOT NULL,
    [Telefono]        VARCHAR (15)  NULL,
    [Email]           VARCHAR (50)  NULL,
    [Imagen]          VARCHAR (150) NULL
);

CREATE TABLE [dbo].[Medicos] (
    [IdMedico]       INT NOT NULL,
    [IdEspecialidad] INT NOT NULL,
    [Estado]         BIT NULL,
    [IdJornada]      INT NULL
);

CREATE TABLE [dbo].[Turnos] (
    [IdTurnos]     INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [IdEmpleado]   INT           NULL,
    [IdPaciente]   INT           NULL,
    [FechaReserva] DATETIME      NOT NULL,
    [Observacion]  VARCHAR (MAX) NOT NULL,
    [IdJornada]    INT           NULL,
    [Estado]       BIT           NOT NULL,
    [Hora]         INT           NULL
);
ALTER TABLE [dbo].[Turnos]
    ADD CONSTRAINT [FK_TurnoIdEmpleado] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleados] ([Id]);
ALTER TABLE [dbo].[Turnos]
    ADD CONSTRAINT [FK_TurnoIdPaciente] FOREIGN KEY ([IdPaciente]) REFERENCES [dbo].[Pacientes] ([IdPaciente]);
ALTER TABLE [dbo].[Turnos]
    ADD CONSTRAINT [FK_TurnoIdJornada] FOREIGN KEY ([IdJornada]) REFERENCES [dbo].[JornadaTurno] (IdJornada);

