using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class AttendanceListController : Controller
    {
        // GET: AttendanceList
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAttendanceList()
        {
            ViewAttendance_bll viewattendanceBll = new ViewAttendance_bll();
            JsonResult jr = new JsonResult();
            List<V_S_T_C> attendanceList = viewattendanceBll.GetList().ToList();

            if (attendanceList.Count != 0)
            {
                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = attendanceList.ToList() };

            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "查询失败!" };
            }
            return jr;
        }
    }
}