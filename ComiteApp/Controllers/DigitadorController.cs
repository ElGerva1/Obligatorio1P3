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
        public DigitadorController(
            IObtenerTodos<DisciplinasListadoDto> obtenerTodas,
            IAlta<DisciplinasAltaDto> alta)
        { 
        _obtenerTodas = obtenerTodas;
            _alta = alta;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_obtenerTodas.Ejecutar());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DisciplinasAltaDto disciplina)
        {
            try
            {
                _alta.Ejecutar(disciplina);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
            }
            return View(disciplina);

        }
    }

}
