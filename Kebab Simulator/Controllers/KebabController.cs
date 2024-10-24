using Kebab_Simulator.Core.Domain.Serviceinterface;
using Kebab_Simulator.Data;
using Kebab_Simulator.Models.KebabModels;
using Microsoft.AspNetCore.Mvc;
// kebabcontroller controlls all things with kebab
namespace Kebab_Simulator.Controllers
{
    public class KebabController : Controller
    {

        private readonly KebabSimulatorContext _context;
        private readonly IKebabSimulatorServices _KebabSimulatorServices;

        public KebabController(KebabSimulatorContext context, IKebabSimulatorServices kebabSimulatorServices)
        {
            _context = context;
            _KebabSimulatorServices = kebabSimulatorServices;
        }

        public IActionResult Index()
        {
            var resultingInventory = _context.Kebabs
                .OrderByDescending(y => y.KebabLevel)
                .Select(x => new KebabIndexViewModel
                {
                    ID = x.ID,
                    KebabName = x.KebabName,
                    KebabLevel = x.KebabLevel,
                    KebabBankAccount = x.KebabBankAccount,
                    KebabStatus = x.KebabStatus,
                    KebabType = (KebabType)x.KebabType,
                });
            return View(resultingInventory);
        }
        [HttpPost]
        public IActionResult Create()
        {
            KebabCreateViewModel vm = new();
            return View("Create", vm);
        }
    }
}
