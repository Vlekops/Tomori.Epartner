using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Tomori.Epartner.Web.App.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SessionAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {  
            if (!context.HttpContext.User.Identity.IsAuthenticated)
                context.Result = new RedirectResult($"~/Account/Login?redirect={context.HttpContext.Request.Path}");
        }

    }

}