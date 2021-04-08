using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1mple_SchoolManager.Entity.Model
{
    public class InfoTeacherModel
    {
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public bool TeacherSex { get; set; }
        public string TeacherIDcard { get; set; }
        public System.DateTime TeacherBirth { get; set; }
        public int TeacherNum { get; set; }
        public string TeacherPhone { get; set; }
        public string TeacherEmail { get; set; }
        public string HomeAddress { get; set; }
        public string TeacherPhotoUrl { get; set; }
        public string TeacherType { get; set; }
        public string Code { get; set; }
    }
}
