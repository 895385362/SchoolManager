using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity.Model
{
    public class InfoScheduleModel
    {
        public int ScheduleID { get; set; }
        public string Schedule { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int ScheduleType { get; set; }
        public bool IsDelete { get; set; }
    }
}
