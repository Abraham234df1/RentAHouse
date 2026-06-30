Desarrolla un proyecto completo llamado Sistema Web de Renta de Departamentos, utilizando ASP.NET Core MVC (.NET 8 o superior) con C# y SQL Server como base de datos.

No quiero un prototipo ni una maqueta. Quiero un proyecto completamente funcional, listo para abrir en Visual Studio y ejecutar, siguiendo arquitectura por capas, principios SOLID y Clean Code.

Tecnologías

Utiliza:

ASP.NET Core MVC
C#
SQL Server
ADO.NET (NO Entity Framework)
Razor Views
Bootstrap 5
HTML5
CSS
JavaScript
Microsoft.Data.SqlClient
Arquitectura

Organiza el proyecto exactamente así:

RentaDepartamentosWeb

Controllers
    DepartamentoController.cs

Models
    Departamento.cs

Data
    ConexionBD.cs

Repositories
    IDepartamentoRepository.cs
    DepartamentoRepository.cs

Services
    IDepartamentoService.cs
    DepartamentoService.cs

Interfaces
    (si son necesarias)

Views

    Home
        Index

    Departamentos
        Index
        Create
        Edit
        Details
        Delete
        Disponibles
        Buscar

wwwroot

Program.cs

appsettings.json

Aplica separación de responsabilidades.

Nunca mezcles SQL dentro de las vistas.

Nunca coloques lógica de negocio dentro del controlador.

Nunca coloques lógica de validación dentro del repositorio.

Base de datos

Genera también el script SQL completo.

Debe crear la base:

RentaDepartamentos

Y la tabla:

Departamentos

Con los siguientes campos:

Id
Direccion
Colonia
Ciudad
Habitaciones
Banios
PrecioRenta
Estado
Arrendatario
FechaInicioRenta

Usar:

Identity
Primary Key
Tipos de datos adecuados
NOT NULL donde corresponda
NULL donde corresponda
Clase ConexionBD

Crear una clase llamada

ConexionBD

Que únicamente sea responsable de abrir conexiones con SQL Server.

Debe leer la cadena desde

appsettings.json

y devolver

SqlConnection

Aplicando el principio de Responsabilidad Única.

Modelo

Crear la clase

Departamento

Con todas las propiedades correspondientes.

Agregar DataAnnotations para validaciones.

Repositorio

Crear una interfaz

IDepartamentoRepository

y su implementación.

Debe contener:

AgregarDepartamento()

ObtenerDepartamentos()

ObtenerPorId()

ActualizarDepartamento()

EliminarDepartamento()

Buscar()

BuscarPorCiudad()

BuscarPorColonia()

BuscarPorEstado()

BuscarPorPrecio()

ObtenerDisponibles()

CambiarEstado()

Todas las consultas deben usar

SqlCommand

con parámetros.

Nunca concatenar SQL.

Nunca usar consultas inseguras.

Servicio

Crear:

IDepartamentoService
DepartamentoService

Aquí debe existir TODA la lógica de negocio.

Validaciones:

La dirección es obligatoria.

La colonia es obligatoria.

La ciudad es obligatoria.

Habitaciones > 0

Baños > 0

Precio > 0

Estado únicamente puede ser:

Disponible

Rentado

Mantenimiento

Si el estado es Rentado:

Arrendatario obligatorio.

FechaInicioRenta obligatoria.

Si el estado es Disponible:

Arrendatario debe quedar vacío.

FechaInicioRenta debe ser NULL.

No permitir guardar datos inválidos.

Lanzar excepciones claras.

Controlador

Crear

DepartamentoController

Con acciones:

Index

Create GET

Create POST

Edit GET

Edit POST

Delete GET

Delete POST

Details

Buscar

Disponibles

CambiarEstado

El controlador solamente debe comunicarse con el servicio.

Nunca acceder directamente a SQL.

Página principal

Crear una página de inicio moderna.

Debe mostrar tarjetas con acceso a:

Registrar departamento

Administrar departamentos

Departamentos disponibles

Buscar departamentos

Mostrar una pequeña descripción del sistema.

Agregar un menú de navegación.

Registro de departamentos

Crear un formulario completo.

Campos:

Dirección

Colonia

Ciudad

Habitaciones

Baños

Precio

Estado

Arrendatario

Fecha inicio renta

El formulario debe:

Validar cliente.

Validar servidor.

Mostrar mensajes de error.

Utilizar Bootstrap.

Lista de departamentos

Mostrar una tabla responsive.

Columnas:

ID

Dirección

Colonia

Ciudad

Habitaciones

Baños

Precio

Estado

Arrendatario

Fecha

Acciones

Cada fila debe tener botones:

Ver

Editar

Eliminar

Cambiar estado

Utilizar badges de colores para el estado.

Disponible:

verde

Rentado:

rojo

Mantenimiento:

amarillo

Buscar departamentos

Crear una pantalla de búsqueda avanzada.

Debe permitir buscar por:

Ciudad

Colonia

Estado

Precio mínimo

Precio máximo

Permitir combinar filtros.

Mostrar resultados instantáneamente.

Departamentos disponibles

Crear una vista exclusiva.

Solo mostrar departamentos con estado

Disponible.

Agregar tarjetas modernas.

Mostrar:

Dirección

Precio

Habitaciones

Ciudad

Botón Ver detalles

Detalles

Mostrar toda la información del departamento.

Diseño tipo tarjeta.

Editar

Formulario completo.

Todos los datos editables.

Mantener validaciones.

Eliminar

Confirmación antes de borrar.

Mensaje de advertencia.

Cambiar estado

Debe permitir cambiar entre:

Disponible

Rentado

Mantenimiento

Si cambia a Rentado:

Solicitar automáticamente:

Arrendatario

Fecha de inicio

Si cambia a Disponible:

Eliminar automáticamente esos datos.

Diseño

Utilizar Bootstrap 5.

Diseño moderno.

Navbar.

Footer.

Tarjetas.

Iconos Bootstrap Icons.

Colores profesionales.

Responsive.

Animaciones suaves.

Tablas elegantes.

Botones modernos.

Mensajes de éxito.

Mensajes de error.

Alertas.

Confirmaciones.

Principios SOLID

Aplicar correctamente:

Single Responsibility

Open Closed

Liskov

Interface Segregation

Dependency Inversion

Utilizar interfaces.

Inyección de dependencias.

Clean Code

Variables descriptivas.

Métodos pequeños.

Sin código duplicado.

Separar responsabilidades.

Código legible.

Comentarios únicamente cuando sean necesarios.

Seguridad

Todas las consultas parametrizadas.

Protección contra SQL Injection.

Validaciones del lado servidor.

Validaciones del lado cliente.

Manejo de excepciones.

Mensajes amigables.

Program.cs

Configurar correctamente:

Dependency Injection

ConexionBD

Repository

Service

MVC

Static Files

Routing

appsettings.json

Crear la cadena:

ConnectionStrings

ConexionSQL

Preparada para SQL Server.

Extras (NO obligatorios pero sí implementarlos)

Agregar:

Paginación.

Ordenamiento de columnas.

Búsqueda en tiempo real.

Modal Bootstrap para eliminar.

Toast notifications.

Confirmaciones con SweetAlert2.

Íconos Bootstrap.

Validaciones en tiempo real.

Filtros dinámicos.

Tarjetas estadísticas:

Total departamentos

Disponibles

Rentados

Mantenimiento

Dashboard inicial.

Documentación

Generar también:

Manual de Usuario

Incluyendo:

Objetivo

Pantallas

Cómo registrar

Cómo buscar

Cómo editar

Cómo eliminar

Cómo cambiar estado

Cómo consultar disponibles

Con espacio para capturas.

Guía de instalación

Explicar:

Instalar Visual Studio

Instalar .NET

Instalar SQL Server

Restaurar paquetes

Ejecutar script SQL

Configurar appsettings.json

Compilar

Ejecutar

Resultado esperado

El proyecto debe entregarse completamente funcional, sin código incompleto, sin pseudocódigo y sin secciones marcadas como "por implementar". Debe incluir todas las clases, interfaces, vistas Razor, controladores, servicios, repositorios, scripts SQL, configuración de dependencias, validaciones, manejo de errores, diseño responsive y documentación, cumpliendo con todos los requisitos del documento proporcionado.