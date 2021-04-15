using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Common;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManager.Entity.Model;

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
        public JsonResult GetTeacherByList(string _search, Info_Leave model, int currentPage = 1, int PageSize = 10)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            ViewTeacher_bll viewteacherbll = new ViewTeacher_bll();
            JsonResult jr = new JsonResult();
            List<V_T_C_N> teacherlist = viewteacherbll.GetList(_search).ToList();
            teacherlist.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
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


        [HttpPost]
        public JsonResult ChangeTeacher(string data, int code)
        {
            try
            {
                CookieModel modelssss = new CookieModel();
                if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
                {
                    return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
                }
                ViewTeacher_bll viewTeacherBll = new ViewTeacher_bll();
                JsonResult jr = new JsonResult();
                bool result = viewTeacherBll.Operation(data,code);
                if (result)
                {
                    jr.Data = new { code = 10000, result = true, message = "修改成功!" };
                }
                else
                {
                    jr.Data = new { code = 10001, result = false, message = "修改失败!" };
                }
                return jr;
            }
            catch (Exception ex)
            {
                FileHelper.Log("Admin", ex.Message, "");
                throw;
            }
        }
    }
}