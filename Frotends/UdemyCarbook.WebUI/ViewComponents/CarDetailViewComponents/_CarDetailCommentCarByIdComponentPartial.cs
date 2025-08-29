using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.ReviewDtos;

namespace UdemyCarbook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentCarByIdComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _CarDetailCommentCarByIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var responsMessage = await client.GetAsync("Review/GetReviewByCarId?id="+id);
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData =await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewByCarIdDto>>(jsonData);
                
                ViewBag.five = values.Count(x => x.RaytingValue == 5);
                ViewBag.four=values.Count(x=>x.RaytingValue == 4);
                ViewBag.three=values.Count(x=>x.RaytingValue==3);
                ViewBag.two=values.Count(x=>x.RaytingValue==2);
                ViewBag.one=values.Count(x=>x.RaytingValue==1);

                int star = values.Count();

                ViewBag.fiveStar=star==0 ? 0:values.Count(x=>x.RaytingValue==5)*100.0/star;
                ViewBag.fourStar=star==0 ? 0 : values.Count(x=>x.RaytingValue==4)*100.0/star;
                ViewBag.threeStar=star==0 ? 0 : values.Count(x=>x.RaytingValue==3)*100.0/star;
                ViewBag.twoStar=star==0 ? 0 : values.Count(x=>x.RaytingValue==2)*100.0/star;
                ViewBag.oneStar=star==0 ? 0 : values.Count(x=>x.RaytingValue==1)*100.0/star;

                return View(values);
            }

            return View();
        }
    }
}
