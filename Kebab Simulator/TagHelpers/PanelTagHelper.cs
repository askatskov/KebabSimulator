using Microsoft.AspNetCore.Mvc;

namespace Kebab_Simulator.TagHelpers
{
    public class PanelTagHelper : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
