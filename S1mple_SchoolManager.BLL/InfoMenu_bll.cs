using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;
using Newtonsoft.Json;
using S1mple_SchoolManager.Entity.Model;

namespace S1mple_SchoolManager.BLL
{
    public class InfoMenu_bll

    {
        private readonly GenericRepository Dao = null;
        public InfoMenu_bll()
        {
            Dao = new GenericRepository();
        }
        public List<Info_Menu> GetList()
        {
            //查询 
            return Dao.GetEntities<Info_Menu>(x => x.IsDelete == false).ToList();
        }

        public Info_Menu GetModel(int ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Menu>(x => x.MenuID == ID).FirstOrDefault();
        }
        public bool Delete(int ID)
        {
            //物理删除
            if (ID>0)
            {
                Info_Menu model = Dao.GetEntities<Info_Menu>(x => x.SubmenuID == ID).FirstOrDefault();
                if (model != null)
                {
                    Dao.Delete<Info_Menu>(model);
                }
            }
            if (Dao.Save())
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool Operation(string data)
        {
            //修改
            if (data != null)
            {
                //反序列化，获取前端传递的数据添加到泛型集合
                var list = JsonConvert.DeserializeObject<List<InfoMenuModel>>(data);
                List<Info_Menu> menulist = new List<Info_Menu>();
                foreach (var item in list)
                {
                    if (item.MenuID > 0)
                    {
                        Info_Menu model = GetModel(item.MenuID);
                        if (model != null)
                        {
                            if (model.MenuID != 0)
                            {
                                model.MenuController = item.MenuController;
                                model.MenuMethod = item.MenuMethod;
                                model.MenuPath = item.MenuPath;
                                model.MenuText = item.MenuText;
                                model.SubmenuID = item.SubmenuID;
                                menulist.Add(model);
                            }
                        }
                        if (menulist.Count > 0)
                        {
                            Dao.Update(menulist);
                            if (Dao.Save())
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (menulist.Count > 0)
                        {
                            Dao.Create(menulist);
                            if (Dao.Save())
                            {
                                return true;
                            }
                        }
                    }

                }

            }
            return false;
        }
    }
}
