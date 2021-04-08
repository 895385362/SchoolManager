using System.Web;
using System.Web.Mvc;

namespace S1mple_SchoolManagerWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
