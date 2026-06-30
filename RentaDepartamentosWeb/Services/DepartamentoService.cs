using RentaDepartamentosWeb.Models;
using RentaDepartamentosWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentaDepartamentosWeb.Services
{
    /// <summary>
    /// Implementación de la lógica de negocio para departamentos.
    /// Valida las reglas de negocio antes de realizar operaciones de persistencia.
    /// </summary>
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repositorio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DepartamentoService"/>.
        /// </summary>
        /// <param name="repositorio">El repositorio de departamentos.</param>
        public DepartamentoService(IDepartamentoRepository repositorio)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
        }

        /// <inheritdoc />
        public void AgregarDepartamento(Departamento departamento)
        {
            ValidarDepartamento(departamento);
            _repositorio.AgregarDepartamento(departamento);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> ObtenerDepartamentos()
        {
            return _repositorio.ObtenerDepartamentos();
        }

        /// <inheritdoc />
        public Departamento? ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> Buscar(string terminoBusqueda)
        {
            if (string.IsNullOrWhiteSpace(terminoBusqueda))
            {
                throw new ArgumentException("El término de búsqueda no puede estar vacío.", nameof(terminoBusqueda));
            }

            return _repositorio.Buscar(terminoBusqueda);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorCiudad(string ciudad)
        {
            if (string.IsNullOrWhiteSpace(ciudad))
            {
                throw new ArgumentException("La ciudad no puede estar vacía.", nameof(ciudad));
            }

            return _repositorio.BuscarPorCiudad(ciudad);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorColonia(string colonia)
        {
            if (string.IsNullOrWhiteSpace(colonia))
            {
                throw new ArgumentException("La colonia no puede estar vacía.", nameof(colonia));
            }

            return _repositorio.BuscarPorColonia(colonia);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
            {
                throw new ArgumentException("El estado no puede estar vacío.", nameof(estado));
            }

            return _repositorio.BuscarPorEstado(estado);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorPrecio(decimal? precioMin, decimal? precioMax)
        {
            if (precioMin.HasValue && precioMax.HasValue && precioMin > precioMax)
            {
                throw new ArgumentException("El precio mínimo no puede ser mayor que el precio máximo.");
            }

            return _repositorio.BuscarPorPrecio(precioMin, precioMax);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarPorCiudadOColonia(string terminoBusqueda)
        {
            return _repositorio.BuscarPorCiudadOColonia(terminoBusqueda);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> BuscarDepartamentos(string? termino, string? ciudad, string? colonia, decimal? precioMin, decimal? precioMax, string? estado)
        {
            IEnumerable<Departamento> resultados = _repositorio.ObtenerDepartamentos();

            if (!string.IsNullOrWhiteSpace(termino))
            {
                resultados = _repositorio.Buscar(termino);
            }

            if (!string.IsNullOrWhiteSpace(ciudad))
            {
                resultados = resultados.Where(d => d.Ciudad.Contains(ciudad, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(colonia))
            {
                resultados = resultados.Where(d => d.Colonia.Contains(colonia, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(estado))
            {
                resultados = resultados.Where(d => d.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase));
            }

            if (precioMin.HasValue)
            {
                resultados = resultados.Where(d => d.PrecioRenta >= precioMin.Value);
            }

            if (precioMax.HasValue)
            {
                resultados = resultados.Where(d => d.PrecioRenta <= precioMax.Value);
            }

            return resultados;
        }

        /// <inheritdoc />
        public void ActualizarDepartamento(Departamento departamento)
        {
            ValidarDepartamento(departamento);
            _repositorio.ActualizarDepartamento(departamento);
        }

        /// <inheritdoc />
        public void EliminarDepartamento(int id)
        {
            _repositorio.EliminarDepartamento(id);
        }

        /// <inheritdoc />
        public void CambiarEstado(int id, string nuevoEstado)
        {
            if (string.IsNullOrWhiteSpace(nuevoEstado))
            {
                throw new ArgumentException("El estado no puede estar vacío.", nameof(nuevoEstado));
            }

            string estadoNormalizado = nuevoEstado.Trim();

            if (estadoNormalizado != "Disponible" && estadoNormalizado != "Rentado" && estadoNormalizado != "Mantenimiento")
            {
                throw new ArgumentException("El estado debe ser 'Disponible', 'Rentado' o 'Mantenimiento'.", nameof(nuevoEstado));
            }

            if (estadoNormalizado == "Rentado")
            {
                var departamentoExistente = _repositorio.ObtenerPorId(id);
                if (departamentoExistente == null)
                {
                    throw new ArgumentException("El departamento especificado no existe.");
                }
                if (string.IsNullOrWhiteSpace(departamentoExistente.Arrendatario))
                {
                    throw new ArgumentException("No se puede cambiar el estado a 'Rentado' si el departamento no tiene un arrendatario asignado.");
                }
            }

            _repositorio.CambiarEstado(id, nuevoEstado);
        }

        /// <inheritdoc />
        public IEnumerable<Departamento> ObtenerDisponibles()
        {
            return _repositorio.ObtenerDisponibles();
        }

        /// <summary>
        /// Valida las reglas de negocio para un departamento.
        /// </summary>
        private void ValidarDepartamento(Departamento departamento)
        {
            if (departamento == null)
            {
                throw new ArgumentNullException(nameof(departamento));
            }

            if (string.IsNullOrWhiteSpace(departamento.Direccion))
            {
                throw new ArgumentException("La dirección no puede estar vacía.", nameof(departamento.Direccion));
            }

            if (string.IsNullOrWhiteSpace(departamento.Colonia))
            {
                throw new ArgumentException("La colonia no puede estar vacía.", nameof(departamento.Colonia));
            }

            if (string.IsNullOrWhiteSpace(departamento.Ciudad))
            {
                throw new ArgumentException("La ciudad no puede estar vacía.", nameof(departamento.Ciudad));
            }

            if (departamento.Habitaciones <= 0)
            {
                throw new ArgumentException("El número de habitaciones debe ser mayor a cero.", nameof(departamento.Habitaciones));
            }

            if (departamento.Banios <= 0)
            {
                throw new ArgumentException("El número de baños debe ser mayor a cero.", nameof(departamento.Banios));
            }

            if (departamento.PrecioRenta <= 0)
            {
                throw new ArgumentException("El precio de renta debe ser mayor a cero.", nameof(departamento.PrecioRenta));
            }

            string estado = departamento.Estado?.Trim() ?? string.Empty;
            if (estado != "Disponible" && estado != "Rentado" && estado != "Mantenimiento")
            {
                throw new ArgumentException("El estado debe ser Disponible, Rentado o Mantenimiento.", nameof(departamento.Estado));
            }

            if (estado == "Rentado")
            {
                if (string.IsNullOrWhiteSpace(departamento.Arrendatario))
                {
                    throw new ArgumentException("Si el estado es Rentado debe existir un Arrendatario.", nameof(departamento.Arrendatario));
                }

                if (!departamento.FechaInicioRenta.HasValue)
                {
                    throw new ArgumentException("Si el estado es Rentado debe establecerse la fecha de inicio de renta.", nameof(departamento.FechaInicioRenta));
                }
            }
        }
    }
}
