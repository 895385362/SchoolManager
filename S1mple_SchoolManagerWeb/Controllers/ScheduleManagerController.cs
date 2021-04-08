using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManager.Entity.Model;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class ScheduleManagerController : Controller
    {
        // GET: ScheduleManager
        public ActionResult ScheduleManager()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult InsertSchedule(InfoScheduleModel scheduleModel)
        //{
        //    InfoSchedule_bll infoScheduleBll = new InfoSchedule_bll();
        //    JsonResult jr = new JsonResult();
        //    bool result = infoScheduleBll.Add(scheduleModel);
        //    if (result)
        //    {
        //        jr.Data = new { code = 10000, result = true, message = "添加成功!"};
        //    }
        //    else
        //    {
        //        jr.Data = new { code = 10001, result = false, message = "添加失败!"};
        //    }
        //    return jr;
        //}

        [HttpPost]
        public JsonResult ChangeSchedule(string scheduleJson)
        {
            InfoSchedule_bll infoScheduleBll = new InfoSchedule_bll();
            JsonResult jr = new JsonResult();
            bool result = infoScheduleBll.Edit(scheduleJson);
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
    }
}