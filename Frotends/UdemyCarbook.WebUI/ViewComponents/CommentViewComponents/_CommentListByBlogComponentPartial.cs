using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        private List<string> GetImageUrls()
        {
            return new List<string>
            {
                "/carbook-master/images/person_1.jpg",
                "/carbook-master/images/person_2.jpg",
                "/carbook-master/images/person_3.jpg",
                "/carbook-master/images/person_4.jpg",
                "/carbook-master/images/person_5.jpg",
                "/carbook-master/images/person_6.jpg",
                "/carbook-master/images/person_7.jpg",
                "/carbook-master/images/person_8.jpg",
                "/carbook-master/images/person_9.jpg",
                "/carbook-master/images/person_10.png",
                "/carbook-master/images/person_11.jpeg",
                "/carbook-master/images/person_12.jpeg",
                "/carbook-master/images/person_13.jpeg",
                "/carbook-master/images/person_14.jpeg",
                "/carbook-master/images/person_15.jpeg",
                "/carbook-master/images/person_16.jpeg",
                "/carbook-master/images/person_17.jpeg",
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<string> imageUrls = GetImageUrls();
            Random rnd = new Random();
            
            ViewBag.blogId = id;
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/Comments/CommentListByBlog?id=" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                foreach (var comment in values)
                {
                    comment.ImageUrl = imageUrls[rnd.Next(imageUrls.Count)];
                }

                return View(values);
            }
            return View();
        }
    }
}
