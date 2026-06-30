using System;

namespace RentaDepartamentosWeb.Models
{
    /// <summary>
    /// Representa un departamento en renta.
    /// </summary>
    public class Departamento
    {
        /// <summary>
        /// Identificador único del departamento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Dirección física del departamento.
        /// </summary>
        public string Direccion { get; set; } = string.Empty;

        /// <summary>
        /// Colonia donde se encuentra ubicado.
        /// </summary>
        public string Colonia { get; set; } = string.Empty;

        /// <summary>
        /// Ciudad del departamento.
        /// </summary>
        public string Ciudad { get; set; } = string.Empty;

        /// <summary>
        /// Número de habitaciones disponibles.
        /// </summary>
        public int Habitaciones { get; set; }

        /// <summary>
        /// Número de baños (admite decimales para medios baños, ej. 1.5).
        /// </summary>
        public decimal Banios { get; set; }

        /// <summary>
        /// Costo mensual de la renta.
        /// </summary>
        public decimal PrecioRenta { get; set; }

        /// <summary>
        /// Estado actual (ej. "Disponible", "Rentado", "Mantenimiento").
        /// </summary>
        public string Estado { get; set; } = string.Empty;

        /// <summary>
        /// Nombre del arrendatario (si está rentado).
        /// </summary>
        public string? Arrendatario { get; set; }

        /// <summary>
        /// Fecha de inicio de la renta (si está rentado).
        /// </summary>
        public DateTime? FechaInicioRenta { get; set; }
    }
}
