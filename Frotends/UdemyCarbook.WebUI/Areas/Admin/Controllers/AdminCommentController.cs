using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        private readonly HttpClient _httpClient;


        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CarApi");
        }


        public async Task<IActionResult> Index()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultCommentDto>>("Comments");
            return View(values);
        }

        public async Task<IActionResult> RemoveComment(int id)
        {
            var responseMessage = await _httpClient.DeleteAsync($"Comments/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
