using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaAplicacion.CasoUso.CasoUsoAtleta;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;

namespace ComiteApp.Controllers
{
    public class EventosController : Controller
    {
        IObtenerTodos<AtletaListadoDto> _obtenerAtletas;
        IObtenerTodos<DisciplinasListadoDto> _obtenerDisciplinas;
        IAlta<EventoAltaDto> _crearAtleta;
        IObtenerTodos<EventoListadoDto> _obtenerEventos;
        public EventosController(
            IObtenerTodos<AtletaListadoDto> obtenerAtletas,
            IObtenerTodos<DisciplinasListadoDto> obtenerDisciplinas,
            IAlta<EventoAltaDto> crearAtleta,
            IObtenerTodos<EventoListadoDto> obtenerEventos
            )
        {
            _obtenerAtletas = obtenerAtletas;
            _obtenerDisciplinas = obtenerDisciplinas;
            _crearAtleta = crearAtleta;
            _obtenerEventos = obtenerEventos;

        }
        public IActionResult Index()
        {
            return View(_obtenerEventos.Ejecutar());
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<DisciplinasListadoDto> disciplinas = _obtenerDisciplinas.Ejecutar().ToList();
            ViewBag.Disciplinas = disciplinas;
            List<AtletaListadoDto> atletas = _obtenerAtletas.Ejecutar().ToList();
            ViewBag.Atletas = atletas;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventoAltaDto evento, List<int> AtletasIds)
        {

            _crearAtleta.Ejecutar(evento);
            return RedirectToAction("Index");
        }
    }
}
