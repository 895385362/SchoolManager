using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

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

        public bool Edit(Info_Menu model)
        {
            //修改
            if (model != null)
            {
                Dao.Update<Info_Menu>(model);
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

        public bool Add(Info_Menu model)
        {
            //添加 
            if (model != null)
            {
                Dao.Create<Info_Menu>(model);
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
    }
}
