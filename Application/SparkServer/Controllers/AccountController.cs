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
                TempData["Error"] = "Token is empty.";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            // DEBUG
            bool isValidToken = false;

            try
            {
                isValidToken = TokenService.TokenIsValidDebug(token, Config.SigningKey);
            }
            catch (Exception exc)
            {
                TempData["Error"] = exc.ToString();
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

            if (!isValidToken)
                return RedirectToAction(actionName: "Index", controllerName: "Home");

            // ORIGINAL CODE

            //if (!TokenService.TokenIsValid(token, Config.SigningKey))
            //{
            //    TempData["Error"] = "Token not valid. Possible signature error." + "\n\nTOKEN: " + token;
            //    return RedirectToAction(actionName: "Index", controllerName: "Home");
            //}

            TokenPayload payload = TokenService.GetPayload(token);

            FormsAuthentication.SetAuthCookie(payload.uid.ToString(), true);

            return RedirectToAction(actionName: "Index", controllerName: "Admin");
        }
    }
}