using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CategoryDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponentsPartial : ViewComponent
    {
        private readonly HttpClient client;

        public _BlogDetailsCategoryViewComponentsPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("Categories");
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