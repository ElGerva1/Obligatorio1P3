using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System;
using static System.Net.WebRequestMethods;
using System.Security.Policy;

namespace WebCliente.Controllers
{
    public class AutorController : Controller
    {

        private string _url = "http://localhost:5259";

        /*   public IActionResult Index(string mensaje, bool error = false)
           {
               //var client = new RestClient(_url);
               //var request = new RestRequest("/api/v1/Autores", Method.Get);
               //RestResponse response = client.Execute(request);

               string token = HttpContext.Session.GetString("token");

               var client = new RestClient("http://localhost:5259");
               var request = new RestRequest("/api/v1/Autores", Method.Get);
               request.AddHeader("Contet-Type", "application/json");
               request.AddHeader("Authorization", $"Bearer {token}");


               // uso la api mediante el post
               RestResponse response = client.Execute(request);
               Console.WriteLine(response.Content);


               JsonSerializerOptions optionsJson = new JsonSerializerOptions
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                   WriteIndented = true
               };

               //// obtiene el json son los autores de la respuesta (response)
               List<AutorDto> autores = JsonSerializer.Deserialize<List<AutorDto>>(response.Content, optionsJson);

               ViewBag.mensaje = mensaje;
               ViewBag.error = error;
               return View(autores);
           }

           public IActionResult Details(int id)
           {
               return View(ObtenerAutorPorId(id));
           }

           public IActionResult Edit(int id) 
           {
               return View(ObtenerAutorPorId(id));
           }

           [HttpPost]
           public IActionResult Edit(int id, AutorDto autor)
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Autores/{id}", Method.Put);


               request.AddHeader("Contet-Type", "application/json");

               var body = JsonSerializer.Serialize(autor);
               request.AddStringBody(body, DataFormat.Json);


               RestResponse response = client.Execute(request);

               if ((int)response.StatusCode == 200)
               {
                   return RedirectToAction("index", new { mensaje = "Se modifico correctamente" });
               }
               else
               {
                   return RedirectToAction("index", new { mensaje = $"Error en la api {response.StatusCode}", error = true });
               }

           }

           public IActionResult DeleteApi(int id)
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Autores/{id}", Method.Delete);
               RestResponse response = client.Execute(request);

               JsonSerializerOptions optionsJson = new JsonSerializerOptions
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                   WriteIndented = true
               };

               if ((int)response.StatusCode == 204)
               {
                   return RedirectToAction("index", new { mensaje = "Se dio de baja" });
               }
               else
               {
                   return RedirectToAction("index", new { mensaje = $"Error en la api {response.StatusCode}", error = true });
               }
           }


           public IActionResult Delete(int id)
           {
               return View(ObtenerAutorPorId(id));
           }


           public IActionResult Create()
           {
               ViewBag.Paises = ObtenerPaises();
               return View();
           }

           [HttpPost]
           public IActionResult Create(AutorDto autor)
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Autores/", Method.Post);


               request.AddHeader("Contet-Type", "application/json");

               var body = JsonSerializer.Serialize(autor);
               request.AddStringBody(body, DataFormat.Json);


               RestResponse response = client.Execute(request);

               if ((int)response.StatusCode == 201)
               {
                   return RedirectToAction("index", new { mensaje = "Se agrego correctamente" });
               }
               else
               {
                   return RedirectToAction("index", new { mensaje = $"Error en la api {response.StatusCode}", error = true });
               }
           }



           private AutorDto ObtenerAutorPorId(int id)
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Autores/{id}", Method.Get);
               RestResponse response = client.Execute(request);

               JsonSerializerOptions optionsJson = new JsonSerializerOptions
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                   WriteIndented = true
               };

               //// obtiene el json son los autores de la respuesta (response)
               AutorDto autor = JsonSerializer.Deserialize<AutorDto>(response.Content, optionsJson);
               return autor;
           }


           private List<PaisDto> ObtenerPaises()
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Paises/", Method.Get);
               RestResponse response = client.Execute(request);

               JsonSerializerOptions optionsJson = new JsonSerializerOptions
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                   WriteIndented = true
               };

               //// obtiene el json son los autores de la respuesta (response)
               var paises = JsonSerializer.Deserialize<List<PaisDto>>(response.Content, optionsJson);
               return paises;
           }


           private AutorDto ObtenerPaisPorId(int id)
           {
               var client = new RestClient(_url);
               var request = new RestRequest($"/api/v1/Autores/{id}", Method.Get);
               RestResponse response = client.Execute(request);

               JsonSerializerOptions optionsJson = new JsonSerializerOptions
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                   WriteIndented = true
               };

               //// obtiene el json son los autores de la respuesta (response)
               AutorDto autor = JsonSerializer.Deserialize<AutorDto>(response.Content, optionsJson);
               return autor;
           }

           */
    }
}
