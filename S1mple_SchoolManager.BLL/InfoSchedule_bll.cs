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
    public class InfoSchedule_bll
    {
        private readonly GenericRepository Dao = null;
        public InfoSchedule_bll()
        {
            Dao = new GenericRepository();
        }
        public List<Info_Schedule> GetList(int ScheduleType)
        {
            //查询 
            return Dao.GetEntities<Info_Schedule>(x => x.IsDelete == false && x.ScheduleType == ScheduleType).ToList();
        }
        public Info_Schedule GetModel(int ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Schedule>(x => x.ScheduleID == ID).FirstOrDefault();
        }
        public bool Delete(int ScheduleType)
        {
            //物理删除
            if (ScheduleType>0)
            {
              var list =  Dao.GetEntities<Info_Schedule>(x => x.ScheduleType == ScheduleType).ToList();
                if (list.Count!=0)
                {
                    Dao.Delete(list);
                }
                else
                {
                    return true;
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

        public bool Operation(int ScheduleType, string data)
        {
            bool flag1 = false;
            //修改
            if (data != null)
            {
                //反序列化，获取前端传递的数据添加到泛型集合
                var list = JsonConvert.DeserializeObject<List<Info_Schedule>>(data);
                List<Info_Schedule>schedulelist = new List<Info_Schedule>();
                InfoSchedule_bll infoScheduleBll = new InfoSchedule_bll();
                bool flag = infoScheduleBll.Delete(ScheduleType);

                if (flag)
                {
                    foreach (var item in list)
                    {
                        if (item.ScheduleID > 0)
                        {
                            //Info_Schedule model = GetModel(item.ScheduleID);
                            //if (model != null)
                            //{
                            //    if (model.ScheduleID != 0)
                            //    {
                            //        model.Schedule = item.Schedule;
                            //        model.StartTime = item.StartTime;
                            //        model.EndTime = item.EndTime;
                            //        schedulelist.Add(model);
                            //    }
                            //}
                            schedulelist.Add(item);

                            if (schedulelist.Count > 0)
                            {
                                Dao.Create(schedulelist);
    
                            }




                            //if (schedulelist.Count > 0)
                            //{
                            //    Dao.Update(schedulelist);
                            //    if (Dao.Save())
                            //    {
                            //        return true;
                            //    }
                            //} 
                        }



                        //else
                        //{
                        //    if (schedulelist.Count > 0)
                        //    {
                        //        Dao.Create(schedulelist);
                        //        if (Dao.Save())
                        //        {
                        //            return true;
                        //        }
                        //    }
                        //}
                    }
                    if (Dao.Save())
                    {
                        flag1 = true;
                        return flag1;
                    }
                }
            }
            return flag1;
        }
    }
}
