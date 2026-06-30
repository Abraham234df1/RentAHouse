using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace RentaDepartamentosWeb.Data
{
    /// <summary>
    /// Se encarga únicamente de gestionar la creación de conexiones a la base de datos SQL Server.
    /// Cumple con el Principio de Responsabilidad Única (SRP).
    /// </summary>
    public class ConexionBD
    {
        private readonly string _cadenaConexion;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ConexionBD"/> leyendo la cadena de conexión.
        /// </summary>
        /// <param name="configuracion">Configuración de la aplicación.</param>
        public ConexionBD(IConfiguration configuracion)
        {
            _cadenaConexion = configuracion.GetConnectionString("ConexionSQL") 
                ?? throw new InvalidOperationException("La cadena de conexión 'ConexionSQL' no está configurada en appsettings.json.");
        }

        /// <summary>
        /// Obtiene y retorna una nueva instancia de <see cref="SqlConnection"/>.
        /// </summary>
        /// <returns>Una conexión de SQL Server.</returns>
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(_cadenaConexion);
        }
    }
}
