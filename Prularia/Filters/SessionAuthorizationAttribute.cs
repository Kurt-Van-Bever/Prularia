using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Prularia.Filters
{
    public class SessionAuthorizationAttribute : AuthorizeAttribute
    {
        private const string SESSION_LOGGEDIN_USER = "LOGGEDIN_USER";

        
    }
}
