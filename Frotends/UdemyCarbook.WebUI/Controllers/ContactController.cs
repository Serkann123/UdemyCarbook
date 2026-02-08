using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.ContactDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactApiService _contactApiService;
        public ContactController(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            SetPage("İletişim", "Bizimle İletişime Geçin");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            var ok = await _contactApiService.CreateAsync(createContactDto);

            if (ok)
                return RedirectToAction("Index", "Default");

            SetPage("İletişim", "Bizimle İletişime Geçin");
            return View(createContactDto);
        }
    }
}
