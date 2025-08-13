using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CategoryDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponentsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _BlogDetailsCategoryViewComponentsPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Categories");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                var randomCategories = values
                .OrderBy(x => Guid.NewGuid())
                .Take(10)
                .ToList();

                return View(randomCategories);
            }
            return View();
        }
    }
}