using WebCliente.Models.Dtos.Usuarios;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace WebApp.Controllers
{

    public class UserController : Controller
    {

        private string _url = "http://localhost:5132/";

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuarioAltaDto usuario)
        {
            try
            {

                var client = new RestClient(_url);
                var request = new RestRequest($"/api/v1/usuarios/", Method.Post);


                request.AddHeader("Contet-Type", "application/json");

                var body = JsonSerializer.Serialize(usuario);
                request.AddStringBody(body, DataFormat.Json);


                RestResponse response = client.Execute(request);

                if ((int)response.StatusCode != 200)
                {
                    throw new Exception("No se pudo obtener el token");
                }

                // obtiene el token de la respuesta (response)
                string token = JsonSerializer.Deserialize<string>(response.Content);

                // guarda en session para futuras pegadas
                HttpContext.Session.SetString("token", token);

                // redirige el flujo al menu
                return Redirect("/disciplina/index");
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
            }


            return View("login");
        }

        public void Logout()
        {
            HttpContext.Session.Clear();
        }

    }
}
