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
            if (Config.DebugMode)
            {
                FormsAuthentication.SetAuthCookie("1", true);
                return RedirectToAction(actionName: "Index", controllerName: "Admin");
            }


            return Redirect(url: Config.SSOLoginURL + Config.SiteID);
        }

        public ActionResult Authenticate(string token)
        {
            // Validate the token
            TokenStatus status = TokenService.ValidateToken(token, Config.SigningKey);

            if (status != TokenStatus.Valid)
            {
                // Expired tokens should request a new token from the server
                if (status == TokenStatus.Expired)
                    return RedirectToAction(actionName: "Login", controllerName: "Account");

                // Something else is wrong with the token and it can't be trusted
                TempData["Error"] = $"Token not valid. Status: {status.ToString()}";
                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }

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

                TempData["Success"] = $"Welcome, {payload.fname} {payload.lname}.";
            }

            // Set local authentication for user
            FormsAuthentication.SetAuthCookie(payload.uid.ToString(), true);

            return RedirectToAction(actionName: "Index", controllerName: "Admin");
        }
    }
}