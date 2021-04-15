using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Common;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManager.Entity.Model;
using S1mple_SchoolManagerWeb.Fileter;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class ScheduleManagerController : BaseController
    {
        // GET: ScheduleManager
        public ActionResult ScheduleManager()
        {
            return View();
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult GetCheckTimeByClass(Info_Schedule model)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            InfoSchedule_bll infoSchedulebll = new InfoSchedule_bll();
            JsonResult jr = new JsonResult();
            List<Info_Schedule> schedulelist = infoSchedulebll.GetList(model.ScheduleType).ToList();

            if (schedulelist.Count != 0)
            {

                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = schedulelist.ToList() };
            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "服务器连接超时!" };
            }
            return jr;
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult ChangeSchedule(int ScheduleType, string data)
        {
            try
            {
                CookieModel modelssss = new CookieModel();
                if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
                {
                    return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
                }
                InfoSchedule_bll infoScheduleBll = new InfoSchedule_bll();
                JsonResult jr = new JsonResult();
                bool result = infoScheduleBll.Operation(ScheduleType, data);
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