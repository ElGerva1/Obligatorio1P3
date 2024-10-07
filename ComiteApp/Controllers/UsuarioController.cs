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

namespace ComiteApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<UsuarioAltaDto> _alta;
        IObtenerTodos<UsuarioListadoDto> _obtenerTodos;
        IObtener<UsuarioAltaDto> _obtenerID;
        IEliminar<UsuarioAltaDto> _eliminar;
        IEditar<UsuarioAltaDto> _editar;

        public UsuarioController(
            IAlta<UsuarioAltaDto> alta,
            IObtenerTodos<UsuarioListadoDto> obtenerTodos,
            IObtener<UsuarioAltaDto> obtenerID,
            IEliminar<UsuarioAltaDto> eliminar,
            IEditar<UsuarioAltaDto> editar
            )
        {
            _alta = alta;
            _obtenerTodos = obtenerTodos;
            _obtenerID = obtenerID;
            _eliminar = eliminar;
            _editar = editar;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_obtenerTodos.Ejecutar());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioAltaDto usuario)
        {
            try
            {
                _alta.Ejecutar(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(usuario);

        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int id)
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

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UsuarioAltaDto Usuario)
        {
            if (id != Usuario.Id)
            {
                return NotFound();
            }
                try
                {
                    _editar.Ejecutar(Usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(Usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");

        }

        // GET: Usuarios/Delete/5
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
            return RedirectToAction("Index");
        }

        private bool UsuarioExists(int id)
        {
            var Usuario = _obtenerID.Ejecutar(id);
            return Usuario != null;
        }
    }
}
