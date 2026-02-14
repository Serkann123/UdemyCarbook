using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.WebUI.ViewModels;
using X.PagedList;
using X.PagedList.Extensions;

namespace UdemyCarbook.WebUI.Extensions
{
    public static class AdminQueryExtensions
    {
        public static IPagedList<T> ToFilteredPagedList<T>(this IEnumerable<T> query, Controller controller,
            BaseFilterRequest request, Func<T, string, bool> searchPredicate = null)
        {
            var search = request.Search?.Trim();

            if (!string.IsNullOrEmpty(search) && searchPredicate != null)
            {
                query = query.Where(item => searchPredicate(item, search));
            }

            controller.ViewBag.CurrentRequest = request;

            return query.ToPagedList(request.Page, request.PageSize);
        }
    }
}
