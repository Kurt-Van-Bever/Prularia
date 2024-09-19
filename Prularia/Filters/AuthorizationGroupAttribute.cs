using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Prularia.Controllers;
using System.Text.Json;

namespace Prularia.Filters
{
    public class AuthorizationGroupAttribute : ActionFilterAttribute
    {
        private readonly string _allowedGroup;

        public AuthorizationGroupAttribute(string allowedGroup)
            => _allowedGroup = allowedGroup;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoggedInUserData? userData = SecurityController.GetSession_LoggedInUser(filterContext.HttpContext);
            
            if (userData == null)
            {
                filterContext.Result = new RedirectResult("~/Security/Login");
                return;
            }

            if (userData.SecurityGroepen.Contains(_allowedGroup) == false)
            {
                filterContext.Result = new RedirectResult("~/Security/NoAccess");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
