using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Excepciones;
using ComiteLogicaNegocio.Excepciones.Usuario;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ComiteApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<Usuario> _alta;
        IObtenerTodos<Usuario> _obtenerTodos;

        public UsuarioController(
            IAlta<Usuario> alta,
            IObtenerTodos<Usuario> obtenerTodos
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
        public IActionResult Create(VMUsuario usuario)
        {
            try
            {
                Usuario unU = new Usuario(
                                      usuario.Email,
                                      usuario.Password);
                _alta.Ejecutar(unU);
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
