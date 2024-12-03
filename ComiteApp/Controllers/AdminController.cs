
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebMvc.Controllers
{
    public class AdminController : Controller
    {


        IAlta<UsuarioAltaDto> _alta;
        IObtenerTodos<UsuarioListadoDto> _obtenerTodos;

        public AdminController(
            IAlta<UsuarioAltaDto> alta,
            IObtenerTodos<UsuarioListadoDto> obtenerTodos
            )
        {
            _alta = alta;
            _obtenerTodos = obtenerTodos;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try {
                var todos = _obtenerTodos.Ejecutar();
                return View(todos);
            } catch (Exception e) {
                ViewBag.Message = e.Message;
                return View();
            }
            
        }
    }
}
