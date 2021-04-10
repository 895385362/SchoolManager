using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity.Model
{
    public class InfoMenuModel
    {
        public int MenuID { get; set; }
        public string MenuController { get; set; }
        public string MenuMethod { get; set; }
        public string MenuPath { get; set; }
        public string MenuText { get; set; }
        public Nullable<int> SubmenuID { get; set; }
        public bool IsDelete { get; set; }
    }
}
