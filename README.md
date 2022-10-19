# TP_Final_Morales_Rangogni
## Proyecto funcional de un sistema de turnos para una clínica

# Propuesta Clínica

Se requiere una aplicación para administrar la asignación de turnos, pacientes y médicos de una
clínica médica.

En el sistema se cargarán los médicos, que estarán asociados a una o más especialidades y a un
turno de trabajo, y los pacientes con toda su información personal. Los turnos de trabajo serán
administrados por el usuario y podrán cargar el horario de entrada y salida que demanden;
pudiendo haber tantos turnos de trabajo como se necesite.

La funcionalidad central de la aplicación es gestionar los tiempos de los especialistas a partir de la
asignación de turnos a los pacientes.

Para dar de alta un turno el usuario deberá seleccionar un paciente (que deberá estar previamente cargado), y seleccionar una especialidad. A partir de la especialidad seleccionada el sistema debería proponerle algunas opciones en cuanto a horarios y médicos. Por ejemplo, si se elige “Dentista” el sistema debería sugerir tres horarios posibles con su respectivo médico. El usuario podrá elegirlo u optar por seguir cargando el formulario de manera manual. El siguiente dato a cargar es el médico, una vez allí se podrá seleccionar un día y se deberán mostrar los horarios disponibles del médico seleccionado en el día seleccionado.
No puede existir más de un turno para el mismo médico, el mismo día a la misma hora. Lo mismo
para el paciente. No se pueden dar de alta turnos vencidos. Por último, se deben cargar las
observaciones que corresponden a la causa por la cual el paciente solicita el turno. Una vez dado
de alta el turno, se le asigna un número y se envía por mail la confirmación del mismo con los
datos correspondientes al paciente (debe tener cargado correctamente el correo electrónico en el
sistema).

Los turnos pueden ser re programados o cancelados pero nunca deberían ser eliminados.
Se puede manejar un modelo de estado para los turnos con fines informativos y estadístcos a futuro. Por ejemplo: Nuevo, Reprogramado, Cancelado, No Asistió, Cerrado, etc.
Los tiempos de los turnos se proponen se configuren de una hora de duración (de 10 a 11, de 11
a 12, etc.).

La aplicación debe manejar seguridad y perfiles de acceso. Por un lado administrador, que puede
ver y manipular todo, por otro lado recepcionista, que puede administrar pacientes y médicos y
dar de alta turnos, y finalmente médicos que sólo podrán ver sus turnos asociados y modificarlos para agregar las observaciones sobre el diagnóstico del paciente.

![software-gestion-clinica-970x420](https://user-images.githubusercontent.com/84431245/196691760-8b4e56c8-fad0-4391-bd8b-8cc521552899.jpg)
