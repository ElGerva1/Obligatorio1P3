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
        IObtener<AtletaAltaDto> _obtenerAtleta;
        IObtener<EventoAltaDto> _obtenerEvento;
        public EventosController(
            IObtenerTodos<AtletaListadoDto> obtenerAtletas,
            IObtenerTodos<DisciplinasListadoDto> obtenerDisciplinas,
            IAlta<EventoAltaDto> crearEvento,
            IObtenerTodos<EventoListadoDto> obtenerEventos,
            IObtener<AtletaAltaDto> obtenerAtleta,
            IObtener<EventoAltaDto> obtenerEvento
            )
        {
            _obtenerAtletas = obtenerAtletas;
            _obtenerDisciplinas = obtenerDisciplinas;
            _crearEvento = crearEvento;
            _obtenerEventos = obtenerEventos;
            _obtenerAtleta = obtenerAtleta;
            _obtenerEvento = obtenerEvento;

        }
        public IActionResult Index(DateTime? filterDate, string message, string sucessMessage)
        {
            ViewBag.Message = message;
            ViewBag.sucessMessage = sucessMessage;

            // Get all events
            var eventos = _obtenerEventos.Ejecutar();

            // Filter by date if filterDate is provided
            if (filterDate.HasValue)
            {
                eventos = eventos.Where(e => e.Inicio.Date == filterDate.Value.Date).ToList();
            }

            return View(eventos);
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
                return RedirectToAction("Index", new { sucessMessage = "Evento creado con exito" });
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

        [HttpGet]
        public IActionResult Details(int id)
        {

            try
            {
                List<AtletaAltaDto> atletas = new List<AtletaAltaDto>();
                EventoAltaDto evento = _obtenerEvento.Ejecutar(id);
                foreach (int i in evento.AtletasIds)
                {
                    atletas.Add(_obtenerAtleta.Ejecutar(i));
                }
                List<DisciplinasListadoDto> disciplinas = _obtenerDisciplinas.Ejecutar().ToList();
                string d = disciplinas.FirstOrDefault(d => d.Id == evento.DisciplinaId)?.Nombre;
                ViewBag.Disciplina = d;
                ViewBag.Atletas = atletas;
                return View(evento);
            }
            catch (Exception e)
            {
                ViewBag.Message = e.Message;
                return View();
            }
        }
        [HttpPost]
        public IActionResult AddPoints(int eventoId, Dictionary<int, int> Atletas)
        {
            // Logic to save points for athletes
            // For example:
            foreach (var atleta in Atletas)
            {
                // Save points logic here
                // Example: _repository.SavePoints(eventoId, atleta.Key, atleta.Value);
            }

            return RedirectToAction("Index", new { sucessMessage = "Puntos guardados exitosamente." });
        }
    }
}
