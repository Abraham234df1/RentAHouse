using System.Collections.Generic;
using RentaDepartamentosWeb.Models;

namespace RentaDepartamentosWeb.Repositories
{
    /// <summary>
    /// Interfaz para el repositorio de departamentos.
    /// Define las operaciones CRUD y de búsqueda requeridas.
    /// </summary>
    public interface IDepartamentoRepository
    {
        /// <summary>
        /// Agrega un nuevo departamento a la base de datos.
        /// </summary>
        /// <param name="departamento">El departamento a agregar.</param>
        void AgregarDepartamento(Departamento departamento);

        /// <summary>
        /// Obtiene todos los departamentos registrados.
        /// </summary>
        /// <returns>Colección de todos los departamentos.</returns>
        IEnumerable<Departamento> ObtenerDepartamentos();

        /// <summary>
        /// Obtiene un departamento específico mediante su identificador.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <returns>El departamento si existe; de lo contrario, null.</returns>
        Departamento? ObtenerPorId(int id);

        /// <summary>
        /// Busca departamentos por coincidencia en varios campos.
        /// </summary>
        /// <param name="terminoBusqueda">El término de búsqueda.</param>
        /// <returns>Colección de departamentos que coinciden con el término.</returns>
        IEnumerable<Departamento> Buscar(string terminoBusqueda);

        /// <summary>
        /// Busca departamentos por ciudad.
        /// </summary>
        /// <param name="ciudad">La ciudad a buscar.</param>
        /// <returns>Colección de departamentos en la ciudad indicada.</returns>
        IEnumerable<Departamento> BuscarPorCiudad(string ciudad);

        /// <summary>
        /// Busca departamentos por colonia.
        /// </summary>
        /// <param name="colonia">La colonia a buscar.</param>
        /// <returns>Colección de departamentos en la colonia indicada.</returns>
        IEnumerable<Departamento> BuscarPorColonia(string colonia);

        /// <summary>
        /// Busca departamentos por estado.
        /// </summary>
        /// <param name="estado">El estado a buscar.</param>
        /// <returns>Colección de departamentos con el estado indicado.</returns>
        IEnumerable<Departamento> BuscarPorEstado(string estado);

        /// <summary>
        /// Busca departamentos por rango de precio.
        /// </summary>
        /// <param name="precioMin">Precio mínimo opcional.</param>
        /// <param name="precioMax">Precio máximo opcional.</param>
        /// <returns>Colección de departamentos que cumplen el rango de precio.</returns>
        IEnumerable<Departamento> BuscarPorPrecio(decimal? precioMin, decimal? precioMax);

        /// <summary>
        /// Busca departamentos por coincidencia en la ciudad o colonia.
        /// </summary>
        /// <param name="terminoBusqueda">El término de búsqueda (ciudad o colonia).</param>
        /// <returns>Colección de departamentos que coinciden con el término.</returns>
        IEnumerable<Departamento> BuscarPorCiudadOColonia(string terminoBusqueda);

        /// <summary>
        /// Actualiza los datos de un departamento existente.
        /// </summary>
        /// <param name="departamento">El departamento con los datos actualizados.</param>
        void ActualizarDepartamento(Departamento departamento);

        /// <summary>
        /// Elimina un departamento por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del departamento a eliminar.</param>
        void EliminarDepartamento(int id);

        /// <summary>
        /// Cambia únicamente el estado de un departamento.
        /// </summary>
        /// <param name="id">Identificador único del departamento.</param>
        /// <param name="nuevoEstado">El nuevo estado del departamento.</param>
        void CambiarEstado(int id, string nuevoEstado);

        /// <summary>
        /// Obtiene la lista de todos los departamentos cuyo estado es "Disponible".
        /// </summary>
        /// <returns>Colección de departamentos disponibles.</returns>
        IEnumerable<Departamento> ObtenerDisponibles();
    }
}
