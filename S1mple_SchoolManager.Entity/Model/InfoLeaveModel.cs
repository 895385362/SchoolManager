using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity.Model
{
    public class InfoLeaveModel
    {
        public string LeaveID { get; set; }
        public string LeaveStuName { get; set; }
        public string LeaveStuNum { get; set; }
        public string LeaveStuDepartment { get; set; }
        public string LeaveStuGrade { get; set; }
        public string LeaveStuClass { get; set; }
        public string LeaveStuReasons { get; set; }
        public string Teacher { get; set; }
        public string TeacherNum { get; set; }
        public bool IsDelete { get; set; }
    }
}
