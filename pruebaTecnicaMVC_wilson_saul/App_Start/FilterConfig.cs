using System.Web;
using System.Web.Mvc;

namespace pruebaTecnicaMVC_wilson_saul
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
