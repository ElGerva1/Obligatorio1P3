
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

        public IActionResult Login(string message)
        {
            ViewBag.Message = message;
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
                ViewBag.Message = e.Message;
                return RedirectToAction("Login", new { message = "Hubo un error" });
            }           
          
            //HttpContext.Session.SetString("esAdmin", usuario.Admin);
            HttpContext.Session.SetString("mail", usuario.Email);

            if (usuario.Admin == true)
            {
                HttpContext.Session.SetString("rol", "admin");
                return Redirect("/admin/index");
                
            }
            else
            {
                HttpContext.Session.SetString("rol", "digitador");
                return Redirect("/usuario/index");
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
