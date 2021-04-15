using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using S1mple_SchoolManager.Entity;
using S1mple_SchoolManager.Entity.Model;

namespace S1mple_SchoolManager.BLL
{
    public class ViewTeacher_bll
    {
        private readonly GenericRepository Dao = null;
        public ViewTeacher_bll()
        {
            Dao = new GenericRepository();
        }
        public List<V_T_C_N> GetList(string _search)
        {
            //查询 
            return Dao.GetEntities<V_T_C_N>(x => x.IsDelete == false&&x.TeacherName== _search||x.TeacherIDcard == _search).ToList();
        }

      
        public List<Info_Teacher> GetList()
        {
            //查询 
            return Dao.GetEntities<Info_Teacher>(x => x.IsDelete == false).ToList();
        }
      
        public Info_Teacher GetModel(Guid ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Teacher>(x => x.TeacherID == ID).FirstOrDefault();
        }
        public bool Delete(Guid ID)
        {
            //物理删除
            if (ID != Guid.Empty)
            {
                Info_Teacher model = Dao.GetEntities<Info_Teacher>(x => x.TeacherID == ID).FirstOrDefault();
                Dao.Delete<Info_Teacher>(model);
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

        public bool Operation(string data, int code)
        {
            //修改
            if (data != null)
            {
                //反序列化，获取前端传递的数据添加到泛型集合
                var list = JsonConvert.DeserializeObject<List<InfoTeacherModel>>(data);
                List<Info_Teacher> leavelist = new List<Info_Teacher>();
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.TeacherID))
                    {
                        Info_Teacher model = GetModel(new Guid(item.TeacherID));
                        if (model != null)
                        {
                            if (model.TeacherID != Guid.Empty)
                            {
                                model.TeacherName = item.TeacherName;
                                model.TeacherSex = item.TeacherSex;
                                model.TeacherIDcard = item.TeacherIDcard;
                                model.TeacherBirth = item.TeacherBirth;
                                model.TeacherNum = item.TeacherNum;
                                model.TeacherPhone = item.TeacherPhone;
                                model.TeacherEmail = item.TeacherEmail;
                                model.HomeAddress = item.HomeAddress;
                                model.TeacherPhotoUrl = item.TeacherPhotoUrl;
                                model.TeacherType = item.TeacherType;
                                model.Code = item.Code;
                                leavelist.Add(model);
                            }
                        }
                        if (leavelist.Count > 0)
                        {
                            Dao.Update(leavelist);
                            if (Dao.Save())
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (leavelist.Count > 0)
                        {
                            Dao.Create(leavelist);
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
