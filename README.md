# PacientesCRUD
Es un sistema web de gestion de pacientes que permite ingresar, ver, actualizar y eliminar pacientes.

## Tecnologias
- HTML
- Bootstrap
- C#
- ASP.NET MVC Framework
- MySQL

## Configurar credenciales de MySQL
En la carpeta PacientesCRUD cree un archivo de texto llamado ".env.local". Luego agregue las credenciales de su base de datos con la siguiente sintaxis:
```
MYSQL_USER=tuusuario
MYSQL_PASSWORD=tucontraseña
```


## Datos
Se pueden ingresar los siguientes datos de un paciente:
- Nombre (Campo obligatorio)
- Apellido (Campo obligatorio)
- DNI (Campo obligatorio)
- Edad
- Telefono
- Direccion
- Email (Campo obligatorio)
- Peso
- Grupo sanguineo
- Estatura
- Fuma
- Bebe

## Paginas
- Ingresar paciente: permite ingresar los datos de un paciente nuevo.
- Editar paciente: permite editar los datos de un paciente.
- Dashboard: muestra en una lista los datos generales (nombre, apellido, DNI, email, telefono y direccion) de todos los pacientes registrados.
- Informacion del paciente: muestra todos los datos ingresados de un paciente.
