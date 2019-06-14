using QuickSSO.Client;
using SparkServer.Application;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace SparkServer.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect(url: Config.SSOLogoutURL + Config.SiteID);
        }

        public ActionResult Login()
        {
            // Request login/authentication from sso.brandonbrun.com
            return Redirect(url: Config.SSOLoginURL + Config.SiteID);
        }

        public ActionResult Authenticate(string token)
        {
            if (String.IsNullOrEmpty(token))
            {
                TempData["Info"] = "Token is empty.";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            if (!TokenService.TokenIsValid(token, Config.SigningKey))
            {
                TempData["Info"] = "Token not valid. Possible signature error.";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            TokenPayload payload = TokenService.GetPayload(token);

            FormsAuthentication.SetAuthCookie(payload.uid.ToString(), true);

            return RedirectToAction(actionName: "Index", controllerName: "Admin");
        }
    }
}