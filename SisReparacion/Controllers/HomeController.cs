using Microsoft.AspNetCore.Mvc;

namespace SistemaReparaciones.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
