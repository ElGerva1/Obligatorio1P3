using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Excepciones;
using ComiteLogicaNegocio.Excepciones.Usuario;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ComiteCompartido.Dtos.Usuarios;

namespace ComiteApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<UsuarioAltaDto> _alta;
        IObtenerTodos<UsuarioListadoDto> _obtenerTodos;

        public UsuarioController(
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
            return View(_obtenerTodos.Ejecutar());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UsuarioAltaDto usuario)
        {
            try
            {
                _alta.Ejecutar(usuario);
                return RedirectToAction("Index");
            }
            catch (EmailUsuarioInvalidoException)
            {
                ViewBag.Message = "Creo que te has equivocado en el mail";
            }
            catch (LogicaNegocioException e)
            {
                ViewBag.Message = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Message = "Hupppp ... Algo anduvo mal";
            }
            return View(usuario);

        }

    }
}
