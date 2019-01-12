using FormsAuth.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuth.Filters
{
    [AttributeUsage(AttributeTargets.Method,Inherited =true,AllowMultiple =true)]
    public class PermissionFilterAtrribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext==null)
            {
                throw new ArgumentNullException("filterContext");
            }
            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                throw new InvalidOperationException("AuthorizeAttribute Cannot Use Within Child Action Cache");
            }
            bool skipAuthorization = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit:true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),inherit:true);
            if (skipAuthorization)
            {
                return;
            }
            if (this.AuthorizeCore(filterContext.HttpContext))
            {
                //这里可以做一些Cache的缓存
                //...
            }
            else
            {
                this.HandleUnauthorizedRequest(filterContext);
            }
        }
        public bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext==null)
            {
                throw new ArgumentNullException("httpContext");
            }
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }
            FormsIdentity user = httpContext.User.Identity as FormsIdentity;
            if (user==null)
            {
                return false;
            }
            //这里根据User获取权限列表
            //.....
            return true;
        }

        public void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}