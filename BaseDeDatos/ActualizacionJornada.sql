USE [Clinica_MORA]
GO

/****** Objeto: Table [dbo].[Turnos] Fecha del script: 13/11/2022 06:12:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Turnos];


GO
CREATE TABLE [dbo].[Turnos] (
    [IdTurnos]         INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpleado]       INT           NULL,
    [IdPaciente]       INT           NULL,
    [FechaReserva]     DATETIME      NOT NULL,
    [Observacion]      VARCHAR (MAX) NOT NULL,
    [IdJornadaTurno] INT           NULL,
    [Estado]           BIT           NOT NULL,
    [Hora]             INT           NULL
);
USE [Clinica_MORA]
GO

/****** Objeto: Table [dbo].[JornadaTurno] Fecha del script: 13/11/2022 06:15:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[JornadaTurno];


GO
CREATE TABLE [dbo].[JornadaTurno] (
    [IdJornada] INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL,
    [Inicio] INT NOT NULL,
    [Fin] INT NOT NULL
);
select * from Empleados
select * from Usuarios

alter table Pacientes add FechaNacimiento datetime null