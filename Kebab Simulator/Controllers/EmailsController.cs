using Kebab_Simulator.Core.Domain.Dto;
using Kebab_Simulator.Core.Domain.Serviceinterface;
using Kebab_Simulator.Models.Emails;
using Microsoft.AspNetCore.Mvc;

namespace Kebab_Simulator.Controllers
{
    public class EmailsController : Controller
    {
        private readonly IEmailsServices _emailsServices;

        public EmailsController(IEmailsServices emailsServices)
        {
            _emailsServices = emailsServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel viewModel)
        {
            var dto = new EmailDto()
            {
                To = viewModel.To,
                Subject = viewModel.Subject,
                Body = viewModel.Body,
            };
            _emailsServices.SendEmail(dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
