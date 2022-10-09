using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Report
{
    public class CourseBrief
    {
        public string CourseName { get; set; }
        public string Code { get; set; }
        public string TeacherName { get; set; }
        public int AssignedStudents { get; set; }
        public List<CourseDetail> Students { get; set; }
    }
}
