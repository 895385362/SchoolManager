using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
    public class ViewAttendance_bll
    {
        private readonly GenericRepository Dao = null;
        public ViewAttendance_bll()
        {
            Dao = new GenericRepository();
        }
        public List<V_S_T_C> GetList()
        {
            //查询 
            return Dao.GetEntities<V_S_T_C>(x => x.IsDelete == false).ToList();
        }
    }
}
