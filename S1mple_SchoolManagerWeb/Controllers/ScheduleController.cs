using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Common;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class ScheduleController : HomePageController
    {
        // GET: Schedule
        public ActionResult ScheduleList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetScheduleList(Info_Schedule model)
        {

            InfoSchedule_bll infoSchedulebll = new InfoSchedule_bll();
            JsonResult jr = new JsonResult();
            List<Info_Schedule> schedulelist = infoSchedulebll.GetList(model.ScheduleType).ToList();

            if (schedulelist.Count!=0)
            {
               
                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = schedulelist.ToList() };
            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "服务器连接超时!" };
            }
            return jr;
        }
    }
}