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
    public class InfoLeave_bll
    {
        private readonly GenericRepository Dao = null;
        public InfoLeave_bll()
        {
            Dao = new GenericRepository();
        }
        public List<Info_Leave> GetList()
        {
            //查询 
            return Dao.GetEntities<Info_Leave>(x => x.IsDelete == false).ToList();
        }
        public Info_Leave GetModel(Guid ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Leave>(x => x.LeaveID == ID).FirstOrDefault();
        }

        //public InfoLeaveModel GetLeaveModel(string ID)
        //{
        //    //获取Model实体
        //    return Dao.GetEntities<InfoLeaveModel>(x => x.LeaveID == ID).FirstOrDefault();
        //}

        public bool Delete(Guid ID)
        {
            //物理删除
            if (ID != Guid.Empty && ID != null)
            {
                Info_Leave model = Dao.GetEntities<Info_Leave>(x => x.LeaveID == ID).FirstOrDefault(); ;
                Dao.Delete<Info_Leave>(model);
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
                var list = JsonConvert.DeserializeObject<List<InfoLeaveModel>>(data);
                List<Info_Leave> leavelist = new List<Info_Leave>();
                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.LeaveID))
                    {
                        Info_Leave model = GetModel(new Guid(item.LeaveID));
                        if (model != null)
                        {
                            if (model.LeaveID != Guid.Empty)
                            {
                                model.LeaveStuName = item.LeaveStuName;
                                model.LeaveStuNum = item.LeaveStuNum;
                                model.LeaveStuDepartment = item.LeaveStuDepartment;
                                model.LeaveStuGrade = item.LeaveStuGrade;
                                model.LeaveStuClass = item.LeaveStuClass;
                                model.LeaveStuReasons = item.LeaveStuReasons;
                                model.Teacher = item.Teacher;
                                model.TeacherNum = item.TeacherNum;
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
