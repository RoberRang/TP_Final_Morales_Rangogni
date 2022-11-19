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

