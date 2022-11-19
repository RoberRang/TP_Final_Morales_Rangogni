CREATE TABLE [dbo].[Turnos] (
    [IdTurnos]       INT           IDENTITY (1, 1) NOT NULL,
    [IdEmpleado]     INT           NULL,
    [IdPaciente]     INT           NULL,
    [FechaReserva]   DATETIME      NOT NULL,
    [Observacion]    VARCHAR (MAX) NOT NULL,
    [IdJornadaTurno] INT           NULL,
    [Estado]         BIT           NOT NULL,
    [Hora]           INT           NULL
);

