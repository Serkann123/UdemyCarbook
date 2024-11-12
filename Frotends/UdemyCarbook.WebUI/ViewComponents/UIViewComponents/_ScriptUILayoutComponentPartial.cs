using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.ViewComponents.UIViewComponents
{
    public class _ScriptUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
