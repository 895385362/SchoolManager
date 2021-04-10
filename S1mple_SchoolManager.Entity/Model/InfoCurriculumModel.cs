using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity.Model
{
    public class InfoCurriculumModel
    {
        public int CurriculumID { get; set; }
        public string Curriculum1 { get; set; }
        public string Curriculum2 { get; set; }
        public string Curriculum3 { get; set; }
        public string Curriculum4 { get; set; }
        public string Curriculum5 { get; set; }
        public string Curriculum6 { get; set; }
        public string Curriculum7 { get; set; }
        public int ID { get; set; }
        public int ScheduleID { get; set; }
        public System.Guid ClassID { get; set; }
        public bool IsDelete { get; set; }
    }
}
