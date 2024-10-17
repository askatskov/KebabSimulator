using Microsoft.AspNetCore.Mvc;
// kebabcontroller controlls all things with kebab
namespace Kebab_Simulator.Controllers
{
    public class KebabController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
