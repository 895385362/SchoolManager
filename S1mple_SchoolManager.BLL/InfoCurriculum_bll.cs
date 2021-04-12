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

        public O_C_S_C GetModels(int CurriculumID, int ScheduleID, Guid ClassID)
        {
            return Dao.GetEntities<O_C_S_C>(x => x.CurriculumID == CurriculumID & x.ScheduleID == ScheduleID & x.ClassID == ClassID).FirstOrDefault();
        }

        public bool Operation(string data)
        {
            //修改
            if (data != null)
            {
                //反序列化，获取前端传递的数据添加到泛型集合
                var list = JsonConvert.DeserializeObject<List<InfoCurriculumModel>>(data);
                List<Info_Curriculum> curriculumlistEdit = new List<Info_Curriculum>();
                List<Info_Curriculum> curriculumlistAdd = new List<Info_Curriculum>();
               
                //循环json集合
                foreach (var item in list)
                {
                    //1. 有课表ID 但是查询不到数据，添加
                    //2. 有课表ID 查询到了数据，更新
                    //3. 没课表ID 添加
                    //课表ID >0 的时候
                    if (item.CurriculumID > 0)
                    {
                        //更新
                        Info_Curriculum model = GetModel(item.CurriculumID);
                        if (model != null)
                        {
                            if (model.CurriculumID != 0)
                            {
                                #region 更新
                                model.Curriculum1 = item.Curriculum1;
                                model.Curriculum2 = item.Curriculum2;
                                model.Curriculum3 = item.Curriculum3;
                                model.Curriculum4 = item.Curriculum4;
                                model.Curriculum5 = item.Curriculum5;
                                model.Curriculum6 = item.Curriculum6;
                                model.Curriculum7 = item.Curriculum7;

                                curriculumlistEdit.Add(model);
                                #endregion
                            }
                        }
                        else
                        {
                            #region 添加
                            //没查询到也要添加
                            model = new Info_Curriculum();
                            model.Curriculum1 = item.Curriculum1;
                            model.Curriculum2 = item.Curriculum2;
                            model.Curriculum3 = item.Curriculum3;
                            model.Curriculum4 = item.Curriculum4;
                            model.Curriculum5 = item.Curriculum5;
                            model.Curriculum6 = item.Curriculum6;
                            model.Curriculum7 = item.Curriculum7;
                            curriculumlistAdd.Add(model);
                            #endregion
                        }
                    }
                    else
                    {
                        #region 添加
                        Info_Curriculum model = new Info_Curriculum();
                        model.Curriculum1 = item.Curriculum1;
                        model.Curriculum2 = item.Curriculum2;
                        model.Curriculum3 = item.Curriculum3;
                        model.Curriculum4 = item.Curriculum4;
                        model.Curriculum5 = item.Curriculum5;
                        model.Curriculum6 = item.Curriculum6;
                        model.Curriculum7 = item.Curriculum7;
                        curriculumlistAdd.Add(model);
                        #endregion
                    }
                }
                //查询关联表是否存在
                O_C_S_C models = GetModels(list.FirstOrDefault().CurriculumID, list.FirstOrDefault().ScheduleID, list.FirstOrDefault().ClassID);
                if (models == null)
                {
                    models = new O_C_S_C();
                    models.CurriculumID = list.FirstOrDefault().CurriculumID;
                    models.ScheduleID = list.FirstOrDefault().ScheduleID;
                    models.ClassID = list.FirstOrDefault().ClassID;
                    Dao.Create(models);
                }

                if (curriculumlistEdit.Count > 0)
                {
                    Dao.Update(curriculumlistEdit);
                }

                if (curriculumlistAdd.Count > 0)
                {
                    Dao.Create(curriculumlistAdd);
                }
                
                if (Dao.Save())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
