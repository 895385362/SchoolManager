using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class TeacherListController : HomePageController
    {
        // GET: TeacherList
        public ActionResult TeacherList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetTeacherList()
        {

            ViewTeacher_bll viewteacherbll = new ViewTeacher_bll();
            JsonResult jr = new JsonResult();
            List<V_T_C_N> teacherlist = viewteacherbll.GetList().ToList();

            if (teacherlist.Count != 0)
            {
                jr.Data = new {code = 10000 , result = true, message = "查询成功!" , data = teacherlist.ToList() };

            }
            else
            {
                jr.Data = new { code = 10001 , result = false, message = "查询失败!" };
            }
            return jr;
        }
    }
}