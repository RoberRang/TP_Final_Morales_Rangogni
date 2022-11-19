CREATE TABLE [dbo].[Empleados] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [IdTipoPerfil] INT          NULL,
    [Nombre]       VARCHAR (50) NOT NULL,
    [Apellido]     VARCHAR (50) NOT NULL,
    [NroDocumento] VARCHAR (10) NOT NULL,
    [FechaAlta]    DATETIME     NOT NULL,
    [Estado]       BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TipoPerfil] FOREIGN KEY ([IdTipoPerfil]) REFERENCES [dbo].[TipoPerfil] ([IdPerfil])
);

