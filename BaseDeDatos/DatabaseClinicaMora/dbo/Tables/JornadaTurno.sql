CREATE TABLE [dbo].[JornadaTurno] (
    [IdJornada]   INT          IDENTITY (1, 1) NOT NULL,
    [Descripcion] VARCHAR (50) NOT NULL,
    [Estado]      BIT          NOT NULL,
    [Inicio]      INT          NOT NULL,
    [Fin]         INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdJornada] ASC)
);

