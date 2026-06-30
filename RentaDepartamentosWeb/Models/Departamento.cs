using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(250, ErrorMessage = "La dirección no puede superar los 250 caracteres.")]
        public string Direccion { get; set; } = string.Empty;

        /// <summary>
        /// Colonia donde se encuentra ubicado.
        /// </summary>
        [Required(ErrorMessage = "La colonia es obligatoria.")]
        [StringLength(100, ErrorMessage = "La colonia no puede superar los 100 caracteres.")]
        public string Colonia { get; set; } = string.Empty;

        /// <summary>
        /// Ciudad del departamento.
        /// </summary>
        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(100, ErrorMessage = "La ciudad no puede superar los 100 caracteres.")]
        public string Ciudad { get; set; } = string.Empty;

        /// <summary>
        /// Número de habitaciones disponibles.
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Las habitaciones deben ser mayores a cero.")]
        public int Habitaciones { get; set; }

        /// <summary>
        /// Número de baños (admite decimales para medios baños, ej. 1.5).
        /// </summary>
        [Range(0.5, 99.9, ErrorMessage = "Los baños deben ser mayores a cero.")]
        public decimal Banios { get; set; }

        /// <summary>
        /// Costo mensual de la renta.
        /// </summary>
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de renta debe ser mayor a cero.")]
        public decimal PrecioRenta { get; set; }

        /// <summary>
        /// Estado actual (ej. "Disponible", "Rentado", "Mantenimiento").
        /// </summary>
        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(50, ErrorMessage = "El estado no puede superar los 50 caracteres.")]
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
