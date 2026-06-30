using Microsoft.Data.SqlClient;
using RentaDepartamentosWeb.Data;
using RentaDepartamentosWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace RentaDepartamentosWeb.Repositories
{
    /// <summary>
    /// Repositorio que implementa operaciones CRUD sobre la tabla Departamentos
    /// utilizando ADO.NET con SqlCommand parametrizado para evitar inyección SQL.
    /// </summary>
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly ConexionBD _conexionBD;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DepartamentoRepository"/>.
        /// </summary>
        /// <param name="conexionBD">El gestor de conexión a la base de datos.</param>
        public DepartamentoRepository(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD ?? throw new ArgumentNullException(nameof(conexionBD));
        }

        /// <inheritdoc />
        public void AgregarDepartamento(Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));

            const string consulta = @"
                INSERT INTO Departamentos (Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta)
                VALUES (@Direccion, @Colonia, @Ciudad, @Habitaciones, @Banios, @PrecioRenta, @Estado, @Arrendatario, @FechaInicioRenta);";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = departamento.Direccion;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = departamento.Colonia;
                comando.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 100).Value = departamento.Ciudad;
                comando.Parameters.Add("@Habitaciones", SqlDbType.Int).Value = departamento.Habitaciones;
                comando.Parameters.Add("@Banios", SqlDbType.Decimal).Value = departamento.Banios;
                comando.Parameters.Add("@PrecioRenta", SqlDbType.Decimal).Value = departamento.PrecioRenta;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = departamento.Estado;
                comando.Parameters.Add("@Arrendatario", SqlDbType.NVarChar, 100).Value = (object?)departamento.Arrendatario ?? DBNull.Value;
                comando.Parameters.Add("@FechaInicioRenta", SqlDbType.DateTime).Value = (object?)departamento.FechaInicioRenta ?? DBNull.Value;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> ObtenerDepartamentos()
        {
            var lista = new List<Departamento>();
            const string consulta = "SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta FROM Departamentos;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public Departamento? ObtenerPorId(int id)
        {
            const string consulta = "SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta FROM Departamentos WHERE Id = @Id;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        return MapearRenglon(lector);
                    }
                }
            }
            return null;
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorCiudadOColonia(string terminoBusqueda)
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta 
                FROM Departamentos 
                WHERE Ciudad LIKE @Termino OR Colonia LIKE @Termino;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Termino", SqlDbType.NVarChar, 150).Value = $"%{terminoBusqueda}%";

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> Buscar(string terminoBusqueda)
        {
            return BuscarPorCiudadOColonia(terminoBusqueda);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorCiudad(string ciudad)
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta
                FROM Departamentos
                WHERE Ciudad LIKE @Ciudad;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 100).Value = $"%{ciudad}%";

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorColonia(string colonia)
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta
                FROM Departamentos
                WHERE Colonia LIKE @Colonia;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = $"%{colonia}%";

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorEstado(string estado)
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta
                FROM Departamentos
                WHERE Estado = @Estado;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = estado;

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorPrecio(decimal? precioMin, decimal? precioMax)
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta
                FROM Departamentos
                WHERE (@PrecioMin IS NULL OR PrecioRenta >= @PrecioMin)
                  AND (@PrecioMax IS NULL OR PrecioRenta <= @PrecioMax);";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@PrecioMin", SqlDbType.Decimal).Value = (object?)precioMin ?? DBNull.Value;
                comando.Parameters.Add("@PrecioMax", SqlDbType.Decimal).Value = (object?)precioMax ?? DBNull.Value;

                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <inheritdoc />
        public void ActualizarDepartamento(Departamento departamento)
        {
            if (departamento == null) throw new ArgumentNullException(nameof(departamento));

            const string consulta = @"
                UPDATE Departamentos 
                SET Direccion = @Direccion, 
                    Colonia = @Colonia, 
                    Ciudad = @Ciudad, 
                    Habitaciones = @Habitaciones, 
                    Banios = @Banios, 
                    PrecioRenta = @PrecioRenta, 
                    Estado = @Estado, 
                    Arrendatario = @Arrendatario, 
                    FechaInicioRenta = @FechaInicioRenta 
                WHERE Id = @Id;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = departamento.Id;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 250).Value = departamento.Direccion;
                comando.Parameters.Add("@Colonia", SqlDbType.NVarChar, 100).Value = departamento.Colonia;
                comando.Parameters.Add("@Ciudad", SqlDbType.NVarChar, 100).Value = departamento.Ciudad;
                comando.Parameters.Add("@Habitaciones", SqlDbType.Int).Value = departamento.Habitaciones;
                comando.Parameters.Add("@Banios", SqlDbType.Decimal).Value = departamento.Banios;
                comando.Parameters.Add("@PrecioRenta", SqlDbType.Decimal).Value = departamento.PrecioRenta;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = departamento.Estado;
                comando.Parameters.Add("@Arrendatario", SqlDbType.NVarChar, 100).Value = (object?)departamento.Arrendatario ?? DBNull.Value;
                comando.Parameters.Add("@FechaInicioRenta", SqlDbType.DateTime).Value = (object?)departamento.FechaInicioRenta ?? DBNull.Value;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public void EliminarDepartamento(int id)
        {
            const string consulta = "DELETE FROM Departamentos WHERE Id = @Id;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public void CambiarEstado(int id, string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado)) throw new ArgumentException("El estado no puede estar vacío.", nameof(nuevoEstado));

            const string consulta = "UPDATE Departamentos SET Estado = @Estado WHERE Id = @Id;";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.Parameters.Add("@Estado", SqlDbType.NVarChar, 50).Value = nuevoEstado;

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> ObtenerDisponibles()
        {
            var lista = new List<Departamento>();
            const string consulta = @"
                SELECT Id, Direccion, Colonia, Ciudad, Habitaciones, Banios, PrecioRenta, Estado, Arrendatario, FechaInicioRenta 
                FROM Departamentos 
                WHERE Estado = N'Disponible';";

            using (var conexion = _conexionBD.ObtenerConexion())
            using (var comando = new SqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearRenglon(lector));
                    }
                }
            }
            return lista;
        }

        /// <summary>
        /// Mapea un renglón del lector de base de datos a un objeto <see cref="Departamento"/>.
        /// </summary>
        private Departamento MapearRenglon(SqlDataReader lector)
        {
            return new Departamento
            {
                Id = lector.GetInt32(lector.GetOrdinal("Id")),
                Direccion = lector.GetString(lector.GetOrdinal("Direccion")),
                Colonia = lector.GetString(lector.GetOrdinal("Colonia")),
                Ciudad = lector.GetString(lector.GetOrdinal("Ciudad")),
                Habitaciones = lector.GetInt32(lector.GetOrdinal("Habitaciones")),
                Banios = lector.GetDecimal(lector.GetOrdinal("Banios")),
                PrecioRenta = lector.GetDecimal(lector.GetOrdinal("PrecioRenta")),
                Estado = lector.GetString(lector.GetOrdinal("Estado")),
                Arrendatario = lector.IsDBNull(lector.GetOrdinal("Arrendatario")) ? null : lector.GetString(lector.GetOrdinal("Arrendatario")),
                FechaInicioRenta = lector.IsDBNull(lector.GetOrdinal("FechaInicioRenta")) ? null : lector.GetDateTime(lector.GetOrdinal("FechaInicioRenta"))
            };
        }
    }
}
