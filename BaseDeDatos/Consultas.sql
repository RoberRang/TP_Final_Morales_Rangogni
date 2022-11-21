INSERT INTO [dbo].[TipoPerfil] ([IdPerfil], [Descripcion], [Estado]) VALUES (1, N'Administrador', 1)
SELECT idPerfil, descripcion, estado FROM TipoPerfil

SELECT idEspecialidad, descripcion, estado FROM Especialidad


SELECT t.IdTurnos, t.IdEmpleado, e.Apellido + ', ' + e.Nombre NombreMedico, t.IdPaciente, p.Apellidos + ', ' + p.Nombres NombrePaciente, t.FechaReserva, t.Observacion, t.IdSituacion, st.Situacion, t.Hora 
FROM Turnos t INNER JOIN Empleados e ON t.IdEmpleado = e.Id INNER JOIN Pacientes P ON t.IdPaciente = p.IdPaciente INNER JOIN SituacionTurno st ON t.IdSituacion = st.IdSituacion
WHERE CAST(t.FechaReserva AS DATE) = CAST(GETDATE() AS date)

Select * from Turnos

SELECT IdTurnos, IdMedico, IdEspecialidad, IdPaciente, FechaReserva, Observacion, IdSituacion, Hora FROM Turnos WHERE IdEmpleado = 2 AND CAST(FechaReserva AS DATE) = '2022-11-21'

SELECT t.IdTurnos IdTurno, t.IdMedico, e.Apellido + ', ' + e.Nombre NombreMedico, t.IdPaciente, p.Apellidos + ', ' + p.Nombres NombrePaciente, t.IdEspecialidad, es.descripcion, 
t.FechaReserva, t.Observacion, t.IdSituacion, st.Situacion, t.Hora FROM Turnos t INNER JOIN Empleados e ON t.IdMedico = e.Id INNER JOIN Pacientes P ON t.IdPaciente = p.IdPaciente 
INNER JOIN Especialidad es ON t.IdEspecialidad = es.IdEspecialidad INNER JOIN SituacionTurno st ON t.IdSituacion = st.IdSituacion WHERE CAST(t.FechaReserva AS DATE) = '2022-11-21'