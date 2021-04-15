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
    public class AttendanceListController : Controller
    {
        // GET: AttendanceList
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult GetCheckWorkByStudent(string _search,int currentPage = 1, int PageSize = 10)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            ViewAttendance_bll viewattendanceBll = new ViewAttendance_bll();
            JsonResult jr = new JsonResult();
            List<V_S_T_C> attendanceList = viewattendanceBll.GetList(_search).ToList();
            attendanceList.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
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