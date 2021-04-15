using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using S1mple_SchoolManager.BLL;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManagerWeb.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult GetMenuByList()
        {

            InfoMenu_bll infomenubll = new InfoMenu_bll();
            JsonResult jr = new JsonResult();
            List<Info_Menu> Menulist = infomenubll.GetList();

            var list = (from item in Menulist
                       where item.SubmenuID == null
                       select new
                       {
                           MenuID = item.MenuID,
                           MenuController = item.MenuController,
                           MenuMethod = item.MenuMethod,
                           MenuPath = item.MenuPath,
                           MenuText = item.MenuText,
                           SubmenuID = item.SubmenuID,
                           IsDelete = item.IsDelete,
                           ChildLists = new List<Info_Menu>()
                       }).ToList();
            //var upperCommands;
            List<Object> ss = new List<object>();
            foreach (var item in list)
            {
                
                var childList = Menulist.Where(x => x.SubmenuID == item.MenuID && x.IsDelete == false).ToList();
                foreach (var s in childList)
                {
                   
                    item.ChildLists.Add(s);
                }
                ss.Add(item);
            }
           var sa = ss.ToList();
            //var childList = Menulist.GroupBy(x => x.SubmenuID, (key, group) => group.ToList()).ToList();
            if (Menulist.Count != 0)
            {
                jr.Data = new { code = 10000 ,message = "成功", data= ss.ToList() };
            
            }
            else
            {
                jr.Data = new { code = 10001, message = "失败!"};
            }
            return jr;

        }
        
    }
}