using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;

namespace ComiteApp.Controllers
{
    public class EventosController : Controller
    {
        IObtenerTodos<AtletaListadoDto> _obtenerAtletas;
        IObtenerTodos<DisciplinasListadoDto> _obtenerDisciplinas;
        IAlta<EventoAltaDto> _crearEvento;
        IObtenerTodos<EventoListadoDto> _obtenerEventos;
        public EventosController(
            IObtenerTodos<AtletaListadoDto> obtenerAtletas,
            IObtenerTodos<DisciplinasListadoDto> obtenerDisciplinas,
            IAlta<EventoAltaDto> crearEvento,
            IObtenerTodos<EventoListadoDto> obtenerEventos
            )
        {
            _obtenerAtletas = obtenerAtletas;
            _obtenerDisciplinas = obtenerDisciplinas;
            _crearEvento = crearEvento;
            _obtenerEventos = obtenerEventos;

        }
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(_obtenerEventos.Ejecutar());
        }

        [HttpGet]
        public IActionResult Create()
        {

            try
            {
                List<DisciplinasListadoDto> disciplinas = _obtenerDisciplinas.Ejecutar().ToList();
                ViewBag.Disciplinas = disciplinas;
                List<AtletaListadoDto> atletas = _obtenerAtletas.Ejecutar().ToList();
                ViewBag.Atletas = atletas;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Create(EventoAltaDto evento)
        {

            try
            {
                _crearEvento.Ejecutar(evento);
                return RedirectToAction("Index", new { message = "Evento creado con exito" });
            }
            catch (Exception e)
            {
                List<DisciplinasListadoDto> disciplinas = _obtenerDisciplinas.Ejecutar().ToList();
                ViewBag.Disciplinas = disciplinas;
                List<AtletaListadoDto> atletas = _obtenerAtletas.Ejecutar().ToList();
                ViewBag.Atletas = atletas;
                ViewBag.Message = e.Message;
                return View();
            }


        }
    }
}
