using CanbulutHukuk.Web.Models.CHModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CanbulutHukuk.Web.Configuration
{
    public class EnsureUserLoggedIn : ActionFilterAttribute
    {
        public EnsureUserLoggedIn() { }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session["LoginUser"] == null)
            {
                context.Result = new RedirectToRouteResult(
                   new RouteValueDictionary
                   {
                    {"controller", "Sevgi"},
                    {"action", "Login"}
                   }
               );
            }
        }
    }
}