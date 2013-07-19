using System.Web;
using System.Web.Mvc;

namespace MvcMonitoreoTemp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}