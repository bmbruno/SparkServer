using QuickSSO.Client;
using SparkServer.Application;
using SparkServer.Core.Repositories;
using SparkServer.Data;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace SparkServer.Controllers
{
    public class AccountController : Controller
    {
        private IAuthorRepository<Author> _authorRepo;

        public AccountController(IAuthorRepository<Author> authorRepo)
        {
            _authorRepo = authorRepo;
        }

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

            // If user ID doesn't exist, create a new user and display welcome message           
            Author existingAuthor = _authorRepo.Get(payload.uid);

            if (existingAuthor == null)
            {
                _authorRepo.Create(new Author() {

                    SSOID = payload.uid,

                    FirstName = payload.fname,
                    LastName = payload.lname,
                    Email = payload.eml,

                    CreateDate = DateTime.Now,
                    Active = true

                });
            }

            // Set authentication for user

            FormsAuthentication.SetAuthCookie(payload.uid.ToString(), true);

            return RedirectToAction(actionName: "Index", controllerName: "Admin");
        }
    }
}