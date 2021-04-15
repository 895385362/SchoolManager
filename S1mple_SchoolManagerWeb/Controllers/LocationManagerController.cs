using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManager.Entity.Model;
using S1mple_SchoolManagerWeb.Fileter;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class LocationManagerController : Controller
    {
        // GET: LocationManager
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult GetTrackLocationByList(string StudentName)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            ViewLocation_bll viewLocationBll = new ViewLocation_bll();
            JsonResult jr = new JsonResult();
            List<V_L_S> locationlist = viewLocationBll.GetList(StudentName).ToList();

            if (locationlist.Count != 0)
            {
                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = locationlist.ToList() };

            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "查询失败!" };
            }
            return jr;
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult GetTeacherLocationList(string TeacherName)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            ViewLocation_bll viewLocationBll = new ViewLocation_bll();
            JsonResult jr = new JsonResult();
            List<V_L_T> locationlist = viewLocationBll.GetTeaLocList(TeacherName).ToList();

            if (locationlist.Count != 0)
            {
                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = locationlist.ToList() };

            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "查询失败!" };
            }
            return jr;
        }
    }
}