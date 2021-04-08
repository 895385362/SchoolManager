using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
    public class ViewCurriculum_bll
    {
        private readonly GenericRepository Dao = null;
        public ViewCurriculum_bll()
        {
            Dao = new GenericRepository();
        }
        public List<V_C_S_C> GetList()
        {
            //查询 
            return Dao.GetEntities<V_C_S_C>(x => x.IsDelete == false).ToList();
        }

    }
}
