using System.Web;
using System.Web.Mvc;

namespace Informatiz.ControleEstoque.API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
