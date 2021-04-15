using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Common;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManagerWeb.Fileter;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class LoginController : HomePageController
    {
        public static string Random { get { return ConfigurationManager.AppSettings["RandomNum"]; } }

        public ActionResult Login()
        {
            return View();
        }

        [AuthorizeFilter]
        [HttpPost]
        public JsonResult GetLoginByPhone(Info_Admin model)
        {
            InfoAdmin_bll infoAdminbll = new InfoAdmin_bll();
            JsonResult jr = new JsonResult();
            List<Info_Admin> admin = infoAdminbll.GetPhoneList(model.Account, model.AdminPwd).ToList();
            //var RandomNum = Guid.NewGuid().ToString().Substring(0, 6);
            var Adminpwd = MD5Helper.GetMd5Hash(model.AdminPwd + Random);
            if (admin.Count != 0)
            {
                foreach(var item in admin)
                {
                    CookieHelper.SetCookie("ID", item.AdminID.ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("Name", item.AdminName.ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("Password", Adminpwd, DateTime.Now.AddMinutes(10));
                }
                jr.Data = new { code = 10000, result = true, message = "登录成功!", returnUrl = Url.Content("~/GetTrackLocationByList") };

            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "账号或密码错误!" };
            }
            return jr;
        }

        //[HttpGet]
        //public JsonResult GetAllGoods()
        //{
        //    return Json(goosdList, JsonRequestBehavior.AllowGet);
        //}
    }
}