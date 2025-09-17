using Microsoft.AspNetCore.SignalR;
using System;
using System.Text.Json;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;

namespace UdemyCarbook.WebApi.Hubs
{
    public class CarHub : Hub
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

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var values = JsonSerializer.Deserialize<GetCarCountQueryResult>(jsonData,options);
                await Clients.All.SendAsync("ReceiveCarCount", values.CarCount ?? 0);
            }
        }
    }
}
