using FormsAuth.Common;
using FormsAuth.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuth.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = base.HttpContext.Request["ReturnUrl"];
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName,string password,string returnUrl)
        {
            if (string.IsNullOrEmpty(userName)||string.IsNullOrEmpty(password))
            {
                return JsonManager.GetError("请确保输入用户名和密码!");
            }
            if (userName=="qiuxianhu"&&password=="123")
            {
                var authUser = new User
                {
                    Name = userName
                };
                FormsAuthenticationTicket authenticationTicket = FormsAuthenticationHelper.CreateAuthenticationTicket(authUser);
                FormsAuthenticationHelper.SetAuthCookie(base.HttpContext, authenticationTicket);
                return base.Redirect(returnUrl);
            }
            return View();
        }

        
    }
}