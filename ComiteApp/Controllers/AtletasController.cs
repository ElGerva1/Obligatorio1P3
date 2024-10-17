using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        public IActionResult Atletas(string message)
        {
            ViewBag.Message = message;
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

            List<DisciplinasListadoDto> disciplinas = _obtenerTodasDisciplinas.Ejecutar().ToList();
            List<DisciplinasListadoDto> discilinasAtleta = new List<DisciplinasListadoDto>();
            foreach (int i in Atleta.DisciplinasIds) {
                DisciplinasListadoDto? disciplina = disciplinas.FirstOrDefault(d => d.Id == i);
                discilinasAtleta.Add(disciplina);
            }
            
            ViewBag.Disciplinas = disciplinas;
            ViewBag.DisciplinasAtleta = discilinasAtleta;
            return View(Atleta);
        }

        // POST: Altetas/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AtletaAltaDto atleta, List<int> DisciplinasDisponiblesIds, List<int> SelectedDisciplinaIds, string action)
        {
            if (id != atleta.id)
            {
                return NotFound();
            }
            try
            {
                if (action == "add")
                {
                    // Get selected disciplines from available list
                    var selectedIds = DisciplinasDisponiblesIds.Where(id => !SelectedDisciplinaIds.Contains(id)).ToList();
                    atleta.DisciplinasIds.AddRange(selectedIds);
                }
                else if (action == "remove")
                {
                    // Remove selected disciplines
                    var idsToRemove = SelectedDisciplinaIds.Where(id => DisciplinasDisponiblesIds.Contains(id)).ToList();
                    foreach (var i in idsToRemove)
                    {
                        atleta.DisciplinasIds.Remove(i);
                    }
                }
                _editar.Ejecutar(atleta);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return RedirectToAction("Atletas");

        }
    }
}
