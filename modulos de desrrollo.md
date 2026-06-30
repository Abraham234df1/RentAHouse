# Módulos de Desarrollo

Este documento divide el proyecto `RentaDepartamentosWeb` en módulos de desarrollo claros y responsables, para trabajar en conjunto de forma ordenada.

## 1. Módulo de Configuración y Entorno
Objetivo: preparar el entorno y asegurar que el proyecto sea ejecutable.

- Verificar `Program.cs` y `appsettings.json`.
- Configurar `ConexionBD` para leer la cadena desde `appsettings.json`.
- Asegurar que el proyecto se ejecute con `dotnet run` y que la base de datos `RentaDepartamentos` exista.
- Validar la existencia de `appsettings.json` con el connection string correcto.
- Documentar el comando para iniciar la aplicación y la URL local.

## 2. Módulo de Base de Datos
Objetivo: crear y mantener el esquema SQL para la aplicación.

- Crear el script SQL completo en `database/script.sql`.
- Generar la base `RentaDepartamentos`.
- Crear la tabla `Departamentos` con los campos indicados:
  - `Id` INT IDENTITY, PRIMARY KEY
  - `Direccion` NVARCHAR(250) NOT NULL
  - `Colonia` NVARCHAR(100) NOT NULL
  - `Ciudad` NVARCHAR(100) NOT NULL
  - `Habitaciones` INT NOT NULL
  - `Banios` DECIMAL(3,1) NOT NULL
  - `PrecioRenta` DECIMAL(18,2) NOT NULL
  - `Estado` NVARCHAR(50) NOT NULL
  - `Arrendatario` NVARCHAR(100) NULL
  - `FechaInicioRenta` DATETIME NULL
- Incluir instrucciones para ejecutar el script en SQL Server.
- Confirmar que la conexión ADO.NET funciona con `SqlConnection`.

## 3. Módulo de Modelo
Objetivo: definir la entidad `Departamento` y sus validaciones.

- Crear `Models/Departamento.cs`.
- Agregar propiedades de acuerdo al esquema SQL.
- Añadir `DataAnnotations` para validación:
  - `Direccion`, `Colonia`, `Ciudad`, `Estado` obligatorios.
  - `Habitaciones` > 0.
  - `Banios` > 0.
  - `PrecioRenta` > 0.
- Garantizar que la clase sea compatible con Razor Views y binding.

## 4. Módulo de Conexión a Datos
Objetivo: implementar la clase `ConexionBD` con responsabilidad única.

- Crear `Data/ConexionBD.cs`.
- Leer la cadena desde `appsettings.json`.
- Devolver `SqlConnection` sin ejecutar consultas.
- Registrar `ConexionBD` en DI en `Program.cs`.

## 5. Módulo de Repositorios
Objetivo: encapsular todas las consultas SQL en una capa dedicada.

- Crear `Repositories/IDepartamentoRepository.cs`.
- Implementar `Repositories/DepartamentoRepository.cs`.
- Métodos requeridos:
  - `AgregarDepartamento()`
  - `ObtenerDepartamentos()`
  - `ObtenerPorId()`
  - `ActualizarDepartamento()`
  - `EliminarDepartamento()`
  - `Buscar()`
  - `BuscarPorCiudad()`
  - `BuscarPorColonia()`
  - `BuscarPorEstado()`
  - `BuscarPorPrecio()`
  - `BuscarPorCiudadOColonia()`
  - `ObtenerDisponibles()`
  - `CambiarEstado()`
- Usar `SqlCommand` con parámetros en todas las consultas.
- Evitar concatenar SQL y consultas inseguras.
- Asegurar que la lógica de validación no esté en el repositorio.

## 6. Módulo de Servicios
Objetivo: implementar toda la lógica de negocio y validaciones.

- Crear `Services/IDepartamentoService.cs`.
- Implementar `Services/DepartamentoService.cs`.
- Validaciones obligatorias en la capa de servicio:
  - Dirección, colonia y ciudad obligatorios.
  - Habitaciones > 0.
  - Baños > 0.
  - Precio > 0.
  - Estado solo `Disponible`, `Rentado`, `Mantenimiento`.
  - Si `Rentado`, debe existir arrendatario y fecha de inicio.
- Delegar llamadas CRUD y búsquedas al repositorio.
- Asegurar que no hay lógica de presentación ni detalles de datos en el servicio.

## 7. Módulo de Controladores
Objetivo: recibir peticiones y devolver vistas sin lógica de negocio.

- Implementar `Controllers/DepartamentoController.cs`.
- Métodos para las acciones:
  - `Index`
  - `Details`
  - `Create` (GET/POST)
  - `Edit` (GET/POST)
  - `Delete` (GET/POST)
  - `Disponibles`
  - `Buscar`
- Usar solo el servicio para obtener datos y validar acciones.
- Devolver vistas y modelos, no ejecutar SQL.
- Manejar errores de validación y mostrar mensajes al usuario.

## 8. Módulo de Vistas
Objetivo: implementar la UI con Razor y Bootstrap 5 sin SQL.

- Utilizar `Views/Home/Index.cshtml` para la página principal.
- Implementar las vistas en `Views/Departamentos/`:
  - `Index` (lista completa y búsqueda rápida)
  - `Create`
  - `Edit`
  - `Details`
  - `Delete`
  - `Disponibles`
  - `Buscar`
- Si es necesario, limpiar carpetas duplicadas (`Views/Departamento/`) y dejar solo `Views/Departamentos/`.
- Asegurar que no haya lógica SQL ni lógica de negocio en las vistas.
- Usar validación de modelos con `asp-validation-for`.
- Usar Bootstrap 5 para diseño limpio.

## 9. Módulo de Registro y Dependencias
Objetivo: asegurar el registro de servicios y rutas.

- Registrar `IDepartamentoRepository`, `IDepartamentoService` y `ConexionBD` en DI.
- Verificar `Program.cs` y `builder.Services.AddControllersWithViews()`.
- Probar enrutamiento predeterminado y controladores.

## 10. Módulo de Pruebas y Verificación
Objetivo: validar el funcionamiento completo.

- Probar que el proyecto compila con `dotnet build`.
- Ejecutar el proyecto con `dotnet run`.
- Verificar que las páginas principales cargan correctamente:
  - `/Departamento/Index`
  - `/Departamento/Buscar`
  - `/Departamento/Disponibles`
- Asegurar que la búsqueda y CRUD funcionan con la base de datos.
- Confirmar que no hay errores de validación inesperados.

## 11. Módulo de Documentación y Entrega
Objetivo: dejar el proyecto listo para abrir en Visual Studio.

- Agregar este plan en `modulos de desrrollo.md`.
- Documentar cómo iniciar la base de datos y ejecutar la app.
- Añadir notas sobre cualquier carpeta duplicada o limpieza necesaria.
- Confirmar que el proyecto cumple SOLID y Clean Code.

---

### Recomendación de trabajo en equipo
- Equipo 1: Base de datos, conexión y configuración.
- Equipo 2: Modelo, repositorio y servicios.
- Equipo 3: Controlador y vistas.
- Equipo 4: Pruebas, revisión de duplicados y documentación.

Este archivo puede usarse como guía para dividir tareas y coordinar el desarrollo del proyecto completo.