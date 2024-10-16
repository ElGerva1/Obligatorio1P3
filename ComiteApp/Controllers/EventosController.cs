using Microsoft.AspNetCore.Mvc;

namespace ComiteApp.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
