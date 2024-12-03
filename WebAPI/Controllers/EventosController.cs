using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Eventos;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class EventosController : Controller
    {
        IObtenerEventosFiltro<EventoConAtletaListadoDto> _obtener;
        public EventosController(
            IObtenerEventosFiltro<EventoConAtletaListadoDto> obtener)
        {
            _obtener = obtener;
        }

        // GET: api/<EventosController>
        [HttpGet("Eventos/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObtenerEventos(
                [FromQuery] int? disciplinaId,   // Filtrar por ID de disciplina
                [FromQuery] DateTime? fechaInicio,  // Filtrar por fecha de inicio
                [FromQuery] DateTime? fechaFin,     // Filtrar por fecha de fin
                [FromQuery] string nombreEvento,    // Filtrar por nombre de evento (búsqueda parcial)
                [FromQuery] int? puntajeMinimo,     // Filtrar por puntaje mínimo
                [FromQuery] int? puntajeMaximo)    // Filtrar por puntaje máximo)
        {
            try
            {
                var eventos = _obtener.Ejecutar(disciplinaId, fechaInicio, fechaFin, nombreEvento, puntajeMinimo, puntajeMaximo);
                if (eventos == null)
                {
                    return StatusCode(204);
                }
                return Ok(eventos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
