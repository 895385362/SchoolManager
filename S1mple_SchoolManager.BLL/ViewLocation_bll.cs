using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
    public class ViewLocation_bll
    {
        private readonly GenericRepository Dao = null;
        public ViewLocation_bll()
        {
            Dao = new GenericRepository();
        }
        public List<V_L_S> GetList(string StudentName)
        {
            //查询 
            return Dao.GetEntities<V_L_S>(x => x.StudentName == StudentName && x.IsDelete == false).ToList();
        }

        public List<V_L_T> GetTeaLocList(string TeacherName)
        {
            //查询 
            return Dao.GetEntities<V_L_T>(x => x.TeacherName == TeacherName && x.IsDelete == false).ToList();
        }

    }
}
