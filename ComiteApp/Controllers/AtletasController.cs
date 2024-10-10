using ComiteCompartido.Dtos.Atletas;
using ComiteCompartido.Dtos.Disciplinas;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;

namespace ComiteApp.Controllers
{
    public class AtletasController : Controller
    {
        IObtenerTodos<AtletaListadoDto> _obtenerTodos;
        public AtletasController(IObtenerTodos<AtletaListadoDto> obtenerTodos) {
            _obtenerTodos = obtenerTodos;
        }

        
        [HttpGet]
        public IActionResult Atletas()
        {
            return View(_obtenerTodos.Ejecutar());
        }
    }
}
