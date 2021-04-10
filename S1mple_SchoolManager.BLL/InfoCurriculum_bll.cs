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
    public class InfoCurriculum_bll
    {
        private readonly GenericRepository Dao = null;
        public InfoCurriculum_bll()
        {
            Dao = new GenericRepository();
        }

        public Info_Curriculum GetModel(int ID)
        {
            //获取Model实体
            return Dao.GetEntities<Info_Curriculum>(x => x.CurriculumID == ID).FirstOrDefault();
        }

        public O_C_S_C GetModels(int ID)
        {
            return Dao.GetEntities<O_C_S_C>(x => x.ID == ID).FirstOrDefault();
        }

        public bool Operation(string data)
        {
            //修改
            if (data != null)
            {
                //反序列化，获取前端传递的数据添加到泛型集合
                var list = JsonConvert.DeserializeObject<List<InfoCurriculumModel>>(data);
                List<Info_Curriculum> curriculumlist = new List<Info_Curriculum>();
                foreach (var item in list)
                {
                    if (item.CurriculumID > 0)
                    {
                        Info_Curriculum model = GetModel(item.CurriculumID);
                        O_C_S_C models = GetModels(item.ID);
                        if (model != null && models != null)
                        {
                            if (model.CurriculumID != 0)
                            {
                                model.Curriculum1 = item.Curriculum1;
                                model.Curriculum2 = item.Curriculum2;
                                model.Curriculum3 = item.Curriculum3;
                                model.Curriculum4 = item.Curriculum4;
                                model.Curriculum5 = item.Curriculum5;
                                model.Curriculum6 = item.Curriculum6;
                                model.Curriculum7 = item.Curriculum7;
                                models.ScheduleID = item.ScheduleID;
                                models.ClassID = item.ClassID;

                                curriculumlist.Add(model);
                            }
                        }
                        if (curriculumlist.Count > 0)
                        {
                            Dao.Update(curriculumlist);
                            if (Dao.Save())
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        if (curriculumlist.Count > 0)
                        {
                            Dao.Create(curriculumlist);
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
