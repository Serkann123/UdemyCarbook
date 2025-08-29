using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarbook.Dto.BlogDtos;
using X.PagedList.Extensions;

namespace UdemyCarbook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly HttpClient client;
        public _AdminDashboardBlogListComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {
            var responsMessage = await client.GetAsync("Blog/GetBlogsAllWithAuthorsList");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogsAllWithAuthorDto>>(jsonData);

                var pagedValues = values.ToPagedList(page, 4);

                return View(pagedValues);
            }
            return View();
        }
    }
}
