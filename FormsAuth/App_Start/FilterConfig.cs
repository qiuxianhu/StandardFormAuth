using FormsAuth.Filters;
using System.Web.Mvc;

namespace FormsAuth.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new PermissionFilterAtrribute());//权限控制
        }
    }
}