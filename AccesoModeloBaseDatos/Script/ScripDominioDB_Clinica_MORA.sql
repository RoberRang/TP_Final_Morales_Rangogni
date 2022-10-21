use master
go
create database Clinica_MORA

go
CREATE TABLE [dbo].[TipoPerfil]
(
	[IdPerfil] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] VARCHAR(50) NOT NULL, 
    [Estado] BIT NOT NULL
)

go
CREATE TABLE [dbo].[Empleados]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdTipoPerfil] INT NULL, 
    [Nombre] VARCHAR(50) NOT NULL, 
    [Apellido] VARCHAR(50) NOT NULL, 
    [NroDocumento] VARCHAR(10) NOT NULL, 
    [FechaAlta] DATETIME NOT NULL, 
    [Estado] BIT NOT NULL
)
alter table Empleados add constraint FK_TipoPerfil foreign key (IdTipoPerfil) references TipoPerfil(IdPerfil)

go
CREATE TABLE [dbo].[Especialidad]
(
	[IdEspecialidad] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] VARCHAR(50) NOT NULL, 
    [Estado] BIT NOT NULL
)

go
CREATE TABLE [dbo].[Pacientes]
(
	[IdPaciente] INT NOT NULL PRIMARY KEY IDENTITY,     
    [Nombres] VARCHAR(50) NOT NULL, 
    [Apellidos] VARCHAR(50) NOT NULL, 
    [NroDocumento] VARCHAR(10) NOT NULL, 
    [FechaNacimeitno] DATETIME NOT NULL, 
    [Sexo] char NOT NULL,
    [FechaAlta] DATETIME NOT NULL, 
    [Estado] BIT NOT NULL,
    [Telefono] VARCHAR(15) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [Imagen] VARCHAR(150) NOT NULL 
)

go
CREATE TABLE [dbo].[SituacionTurno]
(
	[IdSituacion] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Descripcion] VARCHAR(50) NOT NULL, 
    [Estado] BIT NOT NULL
)

go
CREATE TABLE [dbo].[Turnos]
(
	[IdTurnos] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdEmpleado] INT NULL, 
    [IdPaciente] INT NULL, 
    [FechaReserva] DATETIME NOT NULL, 
    [Observacion] VARCHAR(max) NOT NULL, 
    [IdSituacionTurno] INT NULL,     
    [Estado] BIT NOT NULL,
    [Hora] INT NULL 
)
alter table Turnos add constraint FK_IdEmpleado foreign key (IdEmpleado) references Empleados(Id)
alter table Turnos add constraint FK_IdPaciente foreign key (IdPaciente) references Pacientes(IdPaciente)
alter table Turnos add constraint FK_IdSituacionTurno foreign key (IdSituacionTurno) references SituacionTurno(IdSituacion)

go
CREATE TABLE [dbo].[Usuarios]
(
	[IdUsuario] INT NOT NULL PRIMARY KEY IDENTITY, 
    [User] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    [IdEmpleado] INT NOT NULL
)
alter table Usuarios add constraint FK_UserIdEmp foreign key (IdEmpleado) references Empleados(Id)