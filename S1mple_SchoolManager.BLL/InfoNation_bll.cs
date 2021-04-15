using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S1mple_SchoolManager.Entity;

namespace S1mple_SchoolManager.BLL
{
    public class InfoNation_bll
    {
        private readonly GenericRepository Dao = null;
        public InfoNation_bll()
        {
            Dao = new GenericRepository();
        }
        public List<Sys_Nation> GetList()
        {
            //查询 
            return Dao.GetEntities<Sys_Nation>().ToList();
        }
    }
}
