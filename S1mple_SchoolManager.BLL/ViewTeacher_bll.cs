using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
    public class ViewTeacher_bll
    {
        private readonly GenericRepository Dao = null;
        public ViewTeacher_bll()
        {
            Dao = new GenericRepository();
        }
        public List<V_T_C_N> GetList()
        {
            //查询 
            return Dao.GetEntities<V_T_C_N>(x => x.IsDelete == false).ToList();
        }
    }
}
