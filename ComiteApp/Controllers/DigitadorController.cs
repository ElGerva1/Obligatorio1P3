using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Excepciones;
using ComiteLogicaNegocio.Excepciones.Usuario;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ComiteCompartido.Dtos.Usuarios;
using Microsoft.EntityFrameworkCore;
using ComiteCompartido.Dtos.Disciplinas;

namespace ComiteApp.Controllers
{
    public class DigitadorController : Controller
    {
        IObtenerTodos<DisciplinasListadoDto> _obtenerTodas;
        IAlta<DisciplinasAltaDto> _alta;
        IObtener<DisciplinasAltaDto> _obtenerID;
        IEliminar<DisciplinasAltaDto> _eliminar;
        public DigitadorController(
            IObtenerTodos<DisciplinasListadoDto> obtenerTodas,
            IAlta<DisciplinasAltaDto> alta,
            IObtener<DisciplinasAltaDto> obtenerID,
            IEliminar<DisciplinasAltaDto> eliminar)
        { 
        _obtenerTodas = obtenerTodas;
            _alta = alta;
            _obtenerID = obtenerID;
            _eliminar = eliminar;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_obtenerTodas.Ejecutar());
        }
        [HttpGet]
        public IActionResult Disciplinas()
        {
            return View(_obtenerTodas.Ejecutar());
        }
        [HttpGet]
        public IActionResult Eventos()
        {
            return View(_obtenerTodas.Ejecutar());
        }
        [HttpGet]
        public IActionResult Atletas()
        {
            return View(_obtenerTodas.Ejecutar());
        }
        [HttpPost]
        public IActionResult CrearDisciplina(DisciplinasAltaDto disciplina)
        {
            try
            {
                _alta.Ejecutar(disciplina);
                return RedirectToAction("Disciplinas");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(disciplina);

        }
        // GET: Digitador/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Usuario = _obtenerID.Ejecutar(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            return View(Usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Usuario = _obtenerID.Ejecutar(id);
            if (Usuario != null)
            {
                _eliminar.Ejecutar(Usuario);
            }
            return RedirectToAction("Disciplinas");
        }
    }

}
