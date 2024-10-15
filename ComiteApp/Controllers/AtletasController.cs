using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ComiteApp.Controllers
{
    public class AtletasController : Controller
    {
        IObtenerTodos<AtletaListadoDto> _obtenerTodos;
        IObtenerTodos<DisciplinasListadoDto> _obtenerTodasDisciplinas;
        IEditar<AtletaAltaDto> _editar;
        IObtener<AtletaAltaDto> _obtenerID;
        public AtletasController(
            IObtenerTodos<AtletaListadoDto> obtenerTodos,
            IObtenerTodos<DisciplinasListadoDto> obtenerDisciplinas,
            IEditar<AtletaAltaDto> editar,
            IObtener<AtletaAltaDto> obtener
            ) {
            _obtenerTodos = obtenerTodos;
            _obtenerTodasDisciplinas = obtenerDisciplinas;
            _editar = editar;
            _obtenerID = obtener;
            
        }

        
        [HttpGet]
        public IActionResult Atletas()
        {
            return View(_obtenerTodos.Ejecutar());
        }

        // GET: Altetas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Atleta = _obtenerID.Ejecutar(id);
            if (Atleta == null)
            {
                return NotFound();
            }
            ViewBag.Disciplinas = _obtenerTodasDisciplinas.Ejecutar().ToList();
            return View(Atleta);
        }

        // POST: Altetas/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AtletaAltaDto Atleta)
        {
            if (id != Atleta.id)
            {
                return NotFound();
            }
            try
            {
                _editar.Ejecutar(Atleta);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return RedirectToAction("Atletas");

        }
    }
}
