Crea Repositories/IDepartamentoRepository.cs con los métodos:
AgregarDepartamento, ObtenerDepartamentos, ObtenerPorId,
BuscarPorCiudadOColonia, ActualizarDepartamento, EliminarDepartamento,
CambiarEstado, ObtenerDisponibles. Luego crea
Repositories/DepartamentoRepository.cs implementando esa interfaz,
recibiendo ConexionBD por constructor, usando SqlCommand con parámetros
(nunca concatenar SQL) para cada operación CRUD sobre la tabla
Departamentos.