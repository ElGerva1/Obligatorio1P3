using ComiteCompartido.Dtos.Atletas;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AtletaController : Controller
    {
        IObtenerTodosPorDisciplina<AtletaListadoDto> _obtenerPorDisciplina;
        public AtletaController(
            IObtenerTodosPorDisciplina<AtletaListadoDto> obtenerPorDisciplina) {
            _obtenerPorDisciplina = obtenerPorDisciplina;
        }

        // GET: api/<DisciplinasController>
        [HttpGet("Disciplina/{id}/Atletas/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ObtenerAtletas(int id)
        {
            try
            {
                var atletas = _obtenerPorDisciplina.Ejecutar(id);
                if (atletas==null)
                {
                    return StatusCode(204);
                }
                return Ok(atletas);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
