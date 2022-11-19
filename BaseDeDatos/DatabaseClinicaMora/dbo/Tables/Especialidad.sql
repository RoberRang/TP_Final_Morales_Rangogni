CREATE TABLE [dbo].[Especialidad] (
    [IdEspecialidad] INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion]    VARCHAR (50) NOT NULL,
    [Estado]         BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdEspecialidad] ASC)
);

