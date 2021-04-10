using System;
using System.Collections.Generic;
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

            if (admin.Count != 0)
            {
                foreach(var item in admin)
                {
                    CookieHelper.SetCookie("ID", item.AdminID.ToString(), DateTime.Now.AddMinutes(10));
                    CookieHelper.SetCookie("Name", item.AdminName.ToString(), DateTime.Now.AddMinutes(10));
                }
                jr.Data = new { result = true, message = "登录成功!", returnUrl = Url.Content("~//")};

            }
            else
            {
                jr.Data = new { result = false, message = "账号或密码错误!", returnUrl = Url.Content("~//") };
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