using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.ViewComponents.UIViewComponents
{
    public class _MainCoverComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
