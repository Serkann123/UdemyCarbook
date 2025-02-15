﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarbook.Dto.CarDtos;
using UdemyCarbook.Dto.FooterAdressDtos;
using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var bookpickdate = TempData["bookpickdate"];
            var bookoffdate = TempData["bookofdate"];
            var timepick = TempData["timepick"];
            var timeoff = TempData["timeoff"];
            var locationId = TempData["locationId"];

            id = int.Parse(locationId.ToString());

            ViewBag.bookpickdate = bookpickdate;
            ViewBag.timepick = timepick;
            ViewBag.timeoff = timeoff;
            ViewBag.locationId = locationId;
            ViewBag.bookoffdate = bookoffdate;


            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Cars/RentACars?locationId={id}&available=true");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RentACarFilterDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
