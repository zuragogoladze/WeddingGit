﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WeddingMVC.Models;

namespace WeddingMVC.Filters
{
    public class RoleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session["logedInUser"] as User;
            if (user?.Role != 100)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {{"controller", "Home"}, {"action", "Index"}});
            }
            base.OnActionExecuting(filterContext);
        }
    }
}