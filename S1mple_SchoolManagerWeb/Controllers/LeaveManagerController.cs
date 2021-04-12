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
    public class LeaveManagerController : Controller
    {
        // GET: LeaveManager
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetLeaveList(Info_Leave model)
        {

            InfoLeave_bll infoSchedulebll = new InfoLeave_bll();
            JsonResult jr = new JsonResult();
            List<Info_Leave> leavelist = infoSchedulebll.GetList().ToList();

            if (leavelist.Count != 0)
            {

                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = leavelist.ToList() };
            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "服务器连接超时!" };
            }
            return jr;
        }

        [HttpPost]
        public JsonResult ChangeLeave(string data)
        {
            try
            {
                InfoLeave_bll infoLeaveBll = new InfoLeave_bll();
                JsonResult jr = new JsonResult();
                bool result = infoLeaveBll.Operation(data);
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