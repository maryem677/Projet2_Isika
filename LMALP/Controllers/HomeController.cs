using Microsoft.AspNetCore.Mvc;

namespace LMALP.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
