CREATE TABLE [dbo].[Usuarios] (
    [IdUsuario]  INT          IDENTITY (1, 1) NOT NULL,
    [UserLogin]  VARCHAR (50) NOT NULL,
    [Password]   VARCHAR (50) NOT NULL,
    [IdEmpleado] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_UserIdEmp] FOREIGN KEY ([IdEmpleado]) REFERENCES [dbo].[Empleados] ([Id])
);

