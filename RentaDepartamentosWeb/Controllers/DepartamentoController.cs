using Microsoft.AspNetCore.Mvc;
using RentaDepartamentosWeb.Models;
using RentaDepartamentosWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentaDepartamentosWeb.Controllers
{
    /// <summary>
    /// Controlador para la gestión de departamentos mediante la interfaz web.
    /// Delega las acciones al servicio de negocio IDepartamentoService.
    /// </summary>
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _servicio;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="DepartamentoController"/>.
        /// </summary>
        /// <param name="servicio">El servicio de negocio para departamentos.</param>
        public DepartamentoController(IDepartamentoService servicio)
        {
            _servicio = servicio ?? throw new ArgumentNullException(nameof(servicio));
        }

        // GET: Departamento
        /// <summary>
        /// Lista todos los departamentos registrados.
        /// </summary>
        public IActionResult Index()
        {
            var departamentos = _servicio.ObtenerDepartamentos();
            return View("~/Views/Departamentos/Index.cshtml", departamentos);
        }

        // GET: Departamento/Details/5
        /// <summary>
        /// Muestra el detalle de un departamento.
        /// </summary>
        /// <param name="id">Identificador del departamento.</param>
        public IActionResult Details(int id)
        {
            var departamento = _servicio.ObtenerPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View("~/Views/Departamentos/Details.cshtml", departamento);
        }

        // GET: Departamento/Create
        /// <summary>
        /// Muestra la vista para agregar un departamento.
        /// </summary>
        public IActionResult Create()
        {
            return View("~/Views/Departamentos/Create.cshtml");
        }

        // POST: Departamento/Create
        /// <summary>
        /// Procesa la creación de un nuevo departamento aplicando validaciones.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            try
            {
                _servicio.AgregarDepartamento(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View("~/Views/Departamentos/Create.cshtml", departamento);
        }

        // GET: Departamento/Edit/5
        /// <summary>
        /// Muestra la vista de edición para un departamento.
        /// </summary>
        /// <param name="id">Identificador del departamento a editar.</param>
        public IActionResult Edit(int id)
        {
            var departamento = _servicio.ObtenerPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View("~/Views/Departamentos/Edit.cshtml", departamento);
        }

        // POST: Departamento/Edit/5
        /// <summary>
        /// Procesa la actualización de los datos de un departamento.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest();
            }

            try
            {
                _servicio.ActualizarDepartamento(departamento);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View("~/Views/Departamentos/Edit.cshtml", departamento);
        }

        // GET: Departamento/Delete/5
        /// <summary>
        /// Muestra la confirmación de eliminación de un departamento.
        /// </summary>
        /// <param name="id">Identificador del departamento a eliminar.</param>
        public IActionResult Delete(int id)
        {
            var departamento = _servicio.ObtenerPorId(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View("~/Views/Departamentos/Delete.cshtml", departamento);
        }

        // POST: Departamento/Delete/5
        /// <summary>
        /// Procesa la eliminación física de un departamento.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _servicio.EliminarDepartamento(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al eliminar: {ex.Message}");
                var departamento = _servicio.ObtenerPorId(id);
                return View("~/Views/Departamentos/Delete.cshtml", departamento);
            }
        }

        // GET: Departamento/Disponibles
        /// <summary>
        /// Lista únicamente los departamentos con estado "Disponible".
        /// </summary>
        public IActionResult Disponibles()
        {
            var disponibles = _servicio.ObtenerDisponibles();
            return View("~/Views/Departamentos/Disponibles.cshtml", disponibles);
        }

        // GET: Departamento/Buscar
        /// <summary>
        /// Busca departamentos por ciudad, colonia, estado o un rango de precios opcional.
        /// </summary>
        /// <param name="termino">Término de búsqueda para ciudad o colonia.</param>
        /// <param name="ciudad">Ciudad del departamento.</param>
        /// <param name="colonia">Colonia del departamento.</param>
        /// <param name="precioMin">Precio de renta mínimo.</param>
        /// <param name="precioMax">Precio de renta máximo.</param>
        /// <param name="estado">Estado del departamento (Disponible, Rentado, Mantenimiento).</param>
        public IActionResult Buscar(string? termino, string? ciudad, string? colonia, decimal? precioMin, decimal? precioMax, string? estado)
        {
            var resultados = _servicio.BuscarDepartamentos(termino, ciudad, colonia, precioMin, precioMax, estado);

            // Guardar filtros en ViewBag para conservarlos en el formulario
            ViewBag.Termino = termino;
            ViewBag.Ciudad = ciudad;
            ViewBag.Colonia = colonia;
            ViewBag.PrecioMin = precioMin;
            ViewBag.PrecioMax = precioMax;
            ViewBag.Estado = estado;

            return View("~/Views/Departamentos/Buscar.cshtml", resultados);
        }
    }
}
