﻿using Kebab_Simulator.ApplicationServices.Services;
using Kebab_Simulator.Core.Domain.Dto;
using Kebab_Simulator.Core.Domain.Serviceinterface;
using Kebab_Simulator.Data;
using Kebab_Simulator.Models.KebabModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace Kebab_Simulator.Controllers
{
    public class KebabController : Controller
    {

        private readonly KebabSimulatorContext _context;
        private readonly IKebabSimulatorServices _KebabSimulatorServices;
        private readonly IFileServices _fileServices;
        public KebabController(KebabSimulatorContext context, IKebabSimulatorServices kebabSimulatorServices, IFileServices fileServices)
        {
            _context = context;
            _KebabSimulatorServices = kebabSimulatorServices;
            _fileServices = fileServices;
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
                return NotFound();
            }

            var images = await _context.FilesToDatabase
                .Where(t => t.KebabID == id)
                .Select(y => new KebabImageViewModel
                {
                    KebabID = y.KebabID,
                    ImageID = y.ID,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KebabDetailsViewModel
            {
                ID = kebab.ID,
                KebabName = kebab.KebabName,
                KebabXP = kebab.KebabXP,
                KebabXPNextLevel = kebab.KebabXPNextLevel,
                KebabLevel = kebab.KebabLevel,
                KebabBankAccount = kebab.KebabBankAccount,
                Checkout = kebab.Checkout,
                KebabStart = kebab.KebabStart,
                KebabDone = kebab.KebabDone,
            };

            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            if (id == Guid.Empty)
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
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KebabCreateViewModel
            {
                ID = kebab.ID,
                KebabName = kebab.KebabName,
                KebabXP = kebab.KebabXP,
                KebabXPNextLevel = kebab.KebabXPNextLevel,
                KebabLevel = kebab.KebabLevel,
                KebabType = (Models.KebabModels.KebabType)kebab.KebabType,
                KebabStatus = (Models.KebabModels.KebabStatus)kebab.KebabStatus,
                KebabBankAccount = kebab.KebabBankAccount,
                Checkout = kebab.Checkout,
                KebabStart = kebab.KebabStart,
                KebabDone = kebab.KebabDone,
                CreatedAt = kebab.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            vm.Image.AddRange(images);

            return View("Update", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KebabCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var dto = new KebabDto
            {
                ID = (Guid) vm.ID,
                KebabName = vm.KebabName,
                KebabXP = vm.KebabXP,
                KebabXPNextLevel = vm.KebabXPNextLevel,
                KebabLevel = vm.KebabLevel,
                KebabType = (Core.Domain.Dto.KebabType)vm.KebabType,
                KebabStatus = (Core.Domain.Dto.KebabStatus)vm.KebabStatus,
                KebabBankAccount = vm.KebabBankAccount,
                Checkout = vm.Checkout,
                KebabStart = vm.KebabStart,
                KebabDone = vm.KebabDone,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
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

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
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
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();

            var vm = new KebabDeleteViewModel
            {
                ID = kebab.ID,
                KebabName = kebab.KebabName,
                KebabXP = kebab.KebabXP,
                KebabXPNextLevel = kebab.KebabXPNextLevel,
                KebabLevel = kebab.KebabLevel,
                KebabBankAccount = kebab.KebabBankAccount,
                Checkout = kebab.Checkout,
                KebabStart = kebab.KebabStart,
                KebabDone = kebab.KebabDone,
            };

            vm.Image.AddRange(images);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kebabToDelete = await _KebabSimulatorServices.Delete(id);

            if (kebabToDelete == null)
            {
                return NotFound(); 
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(KebabImageViewModel vm)
        {
            var dto = new FileToDatabaseDto()
            {
                ID = vm.ImageID,

            };
            var iamge = await _fileServices.RemoveImageFromDatabase(dto);
            if (iamge != null) { return RedirectToAction("Index"); }
            return RedirectToAction("Index");
        }
    }
}
