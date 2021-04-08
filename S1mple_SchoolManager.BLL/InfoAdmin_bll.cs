using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
   public class InfoAdmin_bll 

    {
        private readonly GenericRepository Dao = null;
        public InfoAdmin_bll()
        {
            Dao = new GenericRepository();
        }
        public List<Info_Admin> GetList()
        {
            //查询 
            return Dao.GetEntities<Info_Admin>(x => x.IsDelete == false).ToList();
        }
        public IEnumerable<Info_Admin> GetPhoneList(string Phone, string PassWord)
        {
            //查询 
            return Dao.GetEntities<Info_Admin>(x => x.IsDelete == false && x.AdminPhone == Phone && x.AdminPwd == PassWord).ToList();
        }
        public Info_Admin GetModel(Guid ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Admin>(x => x.AdminID == ID).FirstOrDefault();
        }
        public bool Delete(Guid ID)
        {
            //物理删除
            if (ID != Guid.Empty)
            {
                Info_Admin model = Dao.GetEntities<Info_Admin>(x => x.AdminID == ID).FirstOrDefault();
                Dao.Delete<Info_Admin>(model);
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

        public bool Edit(Info_Admin model)
        {
            //修改
            if (model != null)
            {
                Dao.Update<Info_Admin>(model);
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

        public bool Add(Info_Admin model)
        {
            //添加 
            if (model != null )
            {
                model.AdminID = Guid.NewGuid();
                Dao.Create<Info_Admin>(model);
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
