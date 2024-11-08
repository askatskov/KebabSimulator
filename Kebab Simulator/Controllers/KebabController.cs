using Kebab_Simulator.Core.Domain.Dto;
using Kebab_Simulator.Core.Domain.Serviceinterface;
using Kebab_Simulator.Data;
using Kebab_Simulator.Models.KebabModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
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
                    KebabType = (Models.KebabModels.KebabType)x.KebabType,
                });
            return View(resultingInventory);
        }
        [HttpGet]
        public IActionResult Create()
        {
            KebabCreateViewModel vm = new();
            return View("Create", vm);
        }



        [HttpPost]
        public async Task<IActionResult> Create(KebabCreateViewModel vm)
        {
            var dto = new KebabDto()
            {
                KebabName = vm.KebabName,
                KebabXP = 0,
                KebabXPNextLevel = 100,
                KebabLevel = 0,
                KebabType = (Core.Domain.Dto.KebabType)vm.KebabType,
                KebabStatus = (Core.Domain.Dto.KebabStatus)vm.KebabStatus,
                KebabBankAccount = vm.KebabBankAccount,
                Checkout = vm.Checkout,
                KebabStart = vm.KebabStart,
                KebabDone = vm.KebabDone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KebabID = x.KebabID,
                }).ToArray()


            };
            var result = await _KebabSimulatorServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kebab = await _KebabSimulatorServices.DetailsAsync(id);

            if (kebab == null)
            {
                return NotFound(); // <- TODO; custom partial view with message, kebab is not located
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.KebabID == id)
                .Select(y => new KebabImageViewModel
                {
                    KebabID = y.KebabID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64, {0},", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();

            var vm = new KebabDetailsViewModel();
            vm.ID = kebab.ID;
            vm.KebabName = kebab.KebabName;
            vm.KebabXP = kebab.KebabXP;
            vm.KebabXPNextLevel = kebab.KebabXPNextLevel;
            vm.KebabLevel = kebab.KebabLevel;
            vm.KebabBankAccount = kebab.KebabBankAccount;
            vm.Checkout = kebab.Checkout;
            vm.KebabStart = kebab.KebabStart;
            vm.KebabDone = kebab.KebabDone;
            kebab.KebabStatus = Core.Domain.KebabStatus.Making;
            vm.Image.AddRange(images);

            return View(vm);

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kebab = await _KebabSimulatorServices.DetailsAsync(id);

            if (kebab == null)
            {
                return NotFound();
            }
            var images = await _context.FilesToDatabase
                .Where(x => x.KebabID == id)
                .Select(y => new KebabImageViewModel
                {
                    KebabID = y.KebabID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64, {0},", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();

            var vm = new KebabCreateViewModel();

            vm.ID = kebab.ID;
            vm.KebabName = kebab.KebabName;
            vm.KebabXP = kebab.KebabXP;
            vm.KebabXPNextLevel = kebab.KebabXPNextLevel;
            vm.KebabLevel = kebab.KebabLevel;
            vm.KebabFoods = (Models.KebabModels.KebabFoods)kebab.KebabFoods;
            vm.KebabType = (Models.KebabModels.KebabType)kebab.KebabType;
            vm.KebabBankAccount = kebab.KebabBankAccount;
            vm.Checkout = kebab.Checkout;
            vm.KebabStart = kebab.KebabStart;
            vm.KebabDone = kebab.KebabDone;
            kebab.KebabStatus = Core.Domain.KebabStatus.Making;
            vm.Image.AddRange(images);
            vm.CreatedAt = kebab.CreatedAt;
            vm.UpdatedAt = DateTime.Now;

            return View("Update", vm);

        }
        [HttpPost]
        public async Task<IActionResult> Update(KebabCreateViewModel vm)
        {
            var dto = new KebabDto()
            {
                KebabName = vm.KebabName,
                KebabXP = 0,
                KebabXPNextLevel = 100,
                KebabLevel = 0,
                KebabType = (Core.Domain.Dto.KebabType)vm.KebabType,
                KebabStatus = (Core.Domain.Dto.KebabStatus)vm.KebabStatus,
                KebabBankAccount = vm.KebabBankAccount,
                Checkout = vm.Checkout,
                KebabStart = vm.KebabStart,
                KebabDone = vm.KebabDone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image
                .Select(x => new FileToDatabaseDto
                {
                    ID = x.ImageID,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    KebabID = x.KebabID,
                }).ToArray()


            };
            var result = await _KebabSimulatorServices.Update(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);

        }
    }
}
