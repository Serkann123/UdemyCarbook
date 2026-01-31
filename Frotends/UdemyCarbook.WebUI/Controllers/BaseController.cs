using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public abstract class BaseController : Controller
    {
        protected void SetPage(string breadcrumbTitle, string pageTitle)
        {
            ViewBag.BreadcrumbTitle = breadcrumbTitle;
            ViewBag.PageTitle = pageTitle;
        }
    }
}
