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
            var AdminID = CookieHelper.GetCookieValue("ID");
            var AdminName = CookieHelper.GetCookieValue("Name");
            var AdminPwd = CookieHelper.GetCookieValue("Password");

            if (Request.RequestType == "GET")
            {
                if (AdminID == null && AdminName == null && AdminPwd == null)
                {
                    JsonResult jresult = new JsonResult();
                    jresult.Data = new { code = 10002, result = 0, message = "权限已过期" };
                    filterContext.Result = new RedirectResult("~/GetLoginByPhone");
                    filterContext.Result = jresult;
                    CookieHelper.ClearCookie(AdminID);
                    CookieHelper.ClearCookie(AdminName);
                    CookieHelper.ClearCookie(AdminPwd);
                    return;
                }
            }
            else
            {
                if (AdminID == null)
                {
                    JsonResult jresult = new JsonResult();
                    jresult.Data = new { code = 10002, result = 0, message = "权限已过期" };
                    filterContext.Result = new RedirectResult("~/GetLoginByPhone");
                    filterContext.Result = jresult;
                    return;
                }
            }


        }
    }
}