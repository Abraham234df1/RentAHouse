using System.Collections.Generic;
using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Services
{
    /// <summary>
    /// Interfaz para el servicio de negocio de departamentos.
    /// Define las reglas de negocio y delegación al repositorio.
    /// </summary>
    public interface IDepartamentoService
    {
        /// <summary>
        /// Agrega un nuevo departamento aplicando validaciones de negocio.
        /// </summary>
        /// <param name="departamento">El departamento a agregar.</param>
        void AgregarDepartamento(Departamento departamento);

        /// <summary>
        /// Obtiene todos los departamentos.
        /// </summary>
        /// <returns>Colección de departamentos.</returns>
        IEnumerable<Departamento> ObtenerDepartamentos();

        /// <summary>
        /// Obtiene un departamento por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <returns>El departamento si existe; de lo contrario, null.</returns>
        Departamento? ObtenerPorId(int id);

        /// <summary>
        /// Busca departamentos por coincidencia en la ciudad o colonia.
        /// </summary>
        /// <param name="terminoBusqueda">El término de búsqueda.</param>
        /// <returns>Colección de departamentos que coinciden con el término.</returns>
        IEnumerable<Departamento> BuscarPorCiudadOColonia(string terminoBusqueda);

        /// <summary>
        /// Actualiza un departamento aplicando validaciones de negocio.
        /// </summary>
        /// <param name="departamento">El departamento con los datos actualizados.</param>
        void ActualizarDepartamento(Departamento departamento);

        /// <summary>
        /// Elimina un departamento por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del departamento a eliminar.</param>
        void EliminarDepartamento(int id);

        /// <summary>
        /// Cambia el estado de un departamento validando las condiciones de negocio.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <param name="nuevoEstado">El nuevo estado del departamento.</param>
        void CambiarEstado(int id, string nuevoEstado);

        /// <summary>
        /// Obtiene la lista de todos los departamentos disponibles.
        /// </summary>
        /// <returns>Colección de departamentos disponibles.</returns>
        IEnumerable<Departamento> ObtenerDisponibles();
    }
}
