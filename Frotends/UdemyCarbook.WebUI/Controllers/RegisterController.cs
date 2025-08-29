using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.RegisterDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient client;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto createRegisterDto)
        {
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("Registers/CreateUser", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Login");
            }

            return View();
        }
    }
}
