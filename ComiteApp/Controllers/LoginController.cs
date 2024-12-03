
using ComiteCompartido.Dtos.Usuarios;
using ComiteLogicaNegocio.InterfacesCasoUso;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComiteApp.Controllers
{
    public class LoginController : Controller
    {

        IObtener<UsuarioAltaDto> _obtenerUno;

        public LoginController(
            IObtener<UsuarioAltaDto> obtenerUno
            )
        {
            _obtenerUno = obtenerUno;
        }

        [HttpGet]
        public IActionResult Login(string message, string sucessMessage, string s)
        {
            ViewBag.Message = message;
            ViewBag.sucessMessage = sucessMessage;
            return View();
        }


        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // ir con el caso de uso 
            UsuarioAltaDto usuario = null;
            try
            {
                usuario = _obtenerUno.Ejecutar(email);
            }
            catch (Exception e)
            {
                return RedirectToAction("Login", new { message= e.Message});
            }           

            HttpContext.Session.SetString("mail", usuario.Email);

            if (usuario.Discriminator == "Admin")
            {
                HttpContext.Session.SetString("rol", "admin");
                return Redirect("/usuario/index");
                
            }
            else
            {
                HttpContext.Session.SetString("rol", "digitador");
                return Redirect("/digitador/index");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
