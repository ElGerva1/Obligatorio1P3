using ComiteLogicaAplicacion.CasoUso.Usuarios;
using ComiteLogicaNegocio.Entidades;
using ComiteLogicaNegocio.Excepciones;
using ComiteLogicaNegocio.Excepciones.Usuario;
using ComiteLogicaNegocio.InterfacesCasoUso;
using ComiteApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.Vo.Excepciones;
using Microsoft.AspNetCore.Http;

namespace ComiteApp.Controllers
{
    public class UsuarioController : Controller
    {
        IAlta<UsuarioAltaDto> _alta;
        IObtenerTodos<UsuarioListadoDto> _obtenerTodos;
        IObtener<UsuarioObtenerDto> _obtener;

        public UsuarioController(
            IAlta<UsuarioAltaDto> alta,
            IObtenerTodos<UsuarioListadoDto> obtenerTodos,
            IObtener<UsuarioObtenerDto> obtener
            )
        {   
            _obtener=obtener;
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
            catch (EmailException e)
            {
                ViewBag.Message = e.Message;
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
        public IActionResult Login()
        {
            if (HttpContext.Session.GetInt32("LogueadoID") != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            Usuario ret = _obtener(Email, Password);
            if (ret != null)
            {
                //HttpContext.Session.SetString("LogueadoESTADO", ret.EstaBloqueado.ToString());
                ///HttpContext.Session.SetInt32("LogueadoID", ret.Id);
                //HttpContext.Session.SetString("LogueadoEMAIL", ret.Email);
                //HttpContext.Session.SetString("LogueadoROL", ret.GetType().Name);
                if (ret is Admin)
                {
                    Admin aux = ret as Admin;
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "ERROR DE DATOS";
                return View();
            }

        }

    }
}
