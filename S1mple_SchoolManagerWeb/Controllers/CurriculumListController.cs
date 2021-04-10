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
    public class CurriculumListController : Controller
    {
        //GET: CurriculumList
        public ActionResult CurriculumList()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCurriculumList()
        {

            ViewCurriculum_bll viewCurriculumBll = new ViewCurriculum_bll();
            JsonResult jr = new JsonResult();
            List<V_C_S_C> curriculumList = viewCurriculumBll.GetList().ToList();

            if (curriculumList.Count != 0)
            {
                jr.Data = new { code = 10000, result = true, message = "查询成功!", data = curriculumList.ToList() };

            }
            else
            {
                jr.Data = new { code = 10001, result = false, message = "查询失败!" };
            }
            return jr;
        }

        public JsonResult ChangeCurriculumList(string data)
        {
            try
            {
                InfoCurriculum_bll infocurriculumBll = new InfoCurriculum_bll();
                JsonResult jr = new JsonResult();
                bool result = infocurriculumBll.Operation(data);
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