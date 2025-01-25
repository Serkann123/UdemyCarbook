using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.ViewComponents.RendACarComponents
{
    public class RendACarFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
