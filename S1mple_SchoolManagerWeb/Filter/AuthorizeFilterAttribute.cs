using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.Common;

namespace S1mple_SchoolManagerWeb.Fileter
{
    public class AuthorizeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var Request = filterContext.HttpContext.Request;
            var Response = filterContext.HttpContext.Response;
            var Admin = CookieHelper.GetCookieValue("userInfo");


            if (Request.RequestType == "GET")
            {
                if (Admin == null)
                {
                    string loginUrl = System.Configuration.ConfigurationManager.AppSettings["Login/GetLoginByPhone"];
                    filterContext.Result = new RedirectResult(loginUrl);
                    return;
                }
            }
            else
            {
                if (Admin == null)
                {
                    string loginUrl = System.Configuration.ConfigurationManager.AppSettings["Login/GetLoginByPhone"];
                    JsonResult jresult = new JsonResult();
                    jresult.Data = new { result = 0, msg = "权限已过期" };
                    filterContext.Result = jresult;
                    return;
                }
            }


        }
    }
}