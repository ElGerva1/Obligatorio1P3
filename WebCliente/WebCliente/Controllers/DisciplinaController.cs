using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using WebCliente.Models.Dtos.Disciplinas;
using WebCliente.Models.Dtos.Atletas;

namespace WebCliente.Controllers
{
    public class DisciplinaController : Controller
    {
        public IActionResult Index(int? id, string mensaje = null, bool error = false)
        {
            string token = HttpContext.Session.GetString("token");

            // Inicializamos variables
            List<DisciplinasListadoDto> disciplinas = new List<DisciplinasListadoDto>();
            List<AtletaListadoDto> atletas = new List<AtletaListadoDto>();

            // Configuración del cliente para la API
            var client = new RestClient("http://localhost:5132");

            // Solicitar disciplinas
            var disciplinaRequest = new RestRequest("/api/v1/Disciplinas", Method.Get);
            disciplinaRequest.AddHeader("Content-Type", "application/json");
            disciplinaRequest.AddHeader("Authorization", $"Bearer {token}");
            RestResponse disciplinaResponse = client.Execute(disciplinaRequest);

            if (disciplinaResponse.IsSuccessful && disciplinaResponse.Content != null)
            {
                JsonSerializerOptions optionsJson = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                disciplinas = JsonSerializer.Deserialize<List<DisciplinasListadoDto>>(disciplinaResponse.Content, optionsJson);
            }
            else
            {
                ViewBag.mensaje = "Error al obtener las disciplinas.";
                ViewBag.error = true;
            }

            // Si se ha seleccionado una disciplina, obtener los atletas
            if (id.HasValue)
            {
                var atletaRequest = new RestRequest($"/Disciplina/{id}/Atletas", Method.Get);
                atletaRequest.AddHeader("Content-Type", "application/json");
                atletaRequest.AddHeader("Authorization", $"Bearer {token}");
                RestResponse atletaResponse = client.Execute(atletaRequest);

                if (atletaResponse.IsSuccessful && atletaResponse.Content != null)
                {
                    JsonSerializerOptions optionsJson = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    atletas = JsonSerializer.Deserialize<List<AtletaListadoDto>>(atletaResponse.Content, optionsJson);
                }
                else
                {
                    ViewBag.mensaje = "Error al obtener los atletas.";
                    ViewBag.error = true;
                }
            }

            // Pasamos las listas y otros datos a la vista
            ViewBag.Disciplinas = disciplinas;
            ViewBag.Atletas = atletas;
            ViewBag.mensaje = mensaje;
            ViewBag.error = error;
            ViewBag.SelectedDisciplinaId = id;

            return View();
        }
    }
}
