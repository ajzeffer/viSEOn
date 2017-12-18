using System.Web;
using System.Web.Mvc;

namespace Viseon.Apps.MvcClient
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
