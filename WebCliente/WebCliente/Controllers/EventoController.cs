using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using WebCliente.Models.Dtos.Eventos;

namespace WebCliente.Controllers
{
    public class EventoController : Controller
    {
        public IActionResult Index(int? disciplinaId, DateTime? fechaInicio, DateTime? fechaFin, string nombreEvento, int? puntajeMinimo, int? puntajeMaximo, string mensaje = null, bool error = false)
        {
            string token = HttpContext.Session.GetString("token");
            List<EventoDto> eventos = new List<EventoDto>();

            try
            {
                var client = new RestClient("http://localhost:5132");

                // Crear la solicitud con parámetros opcionales
                var request = new RestRequest("/Eventos", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", $"Bearer {token}");

                if (disciplinaId.HasValue) request.AddQueryParameter("disciplinaId", disciplinaId.ToString());
                if (fechaInicio.HasValue) request.AddQueryParameter("fechaInicio", fechaInicio.Value.ToString("yyyy-MM-dd"));
                if (fechaFin.HasValue) request.AddQueryParameter("fechaFin", fechaFin.Value.ToString("yyyy-MM-dd"));
                if (!string.IsNullOrEmpty(nombreEvento)) request.AddQueryParameter("nombreEvento", nombreEvento);
                if (puntajeMinimo.HasValue) request.AddQueryParameter("puntajeMinimo", puntajeMinimo.ToString());
                if (puntajeMaximo.HasValue) request.AddQueryParameter("puntajeMaximo", puntajeMaximo.ToString());

                RestResponse response = client.Execute(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    JsonSerializerOptions optionsJson = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    eventos = JsonSerializer.Deserialize<List<EventoDto>>(response.Content, optionsJson);
                }
                else
                {
                    mensaje = "No se encontraron eventos o ocurrió un error al consultar.";
                    error = true;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error: {ex.Message}";
                error = true;
            }

            ViewBag.Eventos = eventos;
            ViewBag.mensaje = mensaje;
            ViewBag.error = error;

            return View();
        }
    }
}
