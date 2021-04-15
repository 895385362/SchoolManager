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
    public class LeaveManagerController : Controller
    {
        // GET: LeaveManager
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult GetLeaveByList(string _search , Info_Leave model,int currentPage = 1, int PageSize = 10)
        {
            CookieModel modelssss = new CookieModel();
            if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
            {
                return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
            }
            InfoLeave_bll infoleavebll = new InfoLeave_bll();
            JsonResult jr = new JsonResult();
            if (!string.IsNullOrEmpty(_search))
            {
                List<Info_Leave> leavelist = infoleavebll.GetList(_search).ToList();
                leavelist.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
                if (leavelist.Count != 0)
                {
                    jr.Data = new { code = 10000, result = true, message = "查询成功!", data = leavelist.ToList() };
                }
                else
                {
                    jr.Data = new { code = 10001, result = false, message = "未查询到相关用户!" };
                }
            }
            else
            {
                List<Info_Leave> leavelists = infoleavebll.GetListAll().ToList();
                leavelists.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();
                if (leavelists.Count != 0)
                {
                    jr.Data = new { code = 10000, result = true, message = "查询成功!", data = leavelists.ToList() };
                }
                else
                {
                    jr.Data = new { code = 10001, result = false, message = "服务器连接超时!" };
                }
            }
           
           
            
            return jr;
        }

        [AuthorizeFilterAttribute]
        [HttpPost]
        public JsonResult ChangeLeave(string state , int num)
        {
            try
            {
                CookieModel modelssss = new CookieModel();
                if (string.IsNullOrEmpty(modelssss.UserCookieID) && string.IsNullOrEmpty(modelssss.UserCookieName) && string.IsNullOrEmpty(modelssss.UserCookiePwd))
                {
                    return new JsonResult() { Data = new { code = 10002, result = 0, message = "权限已过期" } };
                }
                InfoLeave_bll infoLeaveBll = new InfoLeave_bll();
                JsonResult jr = new JsonResult();
                bool result = infoLeaveBll.Edit(state,num);
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