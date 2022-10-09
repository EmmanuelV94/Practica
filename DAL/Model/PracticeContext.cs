using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class PracticeContext: DbContext
    {
        public PracticeContext(): base("PracticeDB") { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Teacher> Teachers{ get; set; }
        public virtual DbSet<CourseAssignment> Assignments { get; set; }

    }
}
