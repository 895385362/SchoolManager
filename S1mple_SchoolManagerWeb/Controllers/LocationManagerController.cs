using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class LocationManagerController : Controller
    {
        // GET: LocationManager
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudentLocationList(string StudentName)
        {
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

        [HttpPost]
        public JsonResult GetTeacherLocationList(string TeacherName)
        {
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