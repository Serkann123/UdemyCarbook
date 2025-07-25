﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.ContactDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Contacts");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> RemoveContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7126/api/Contacts/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}