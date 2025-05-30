﻿using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.WebApi.Hubs
{
    public class CarHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCount");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                await Clients.All.SendAsync("ReceiveCarCount", values.CarCount);
            }
        }
    }
}
