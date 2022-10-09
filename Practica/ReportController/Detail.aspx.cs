using DAL.Model.Report;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.ReportController
{
    public partial class Detail : System.Web.UI.Page
    {
        private CourseLogic courseBO;
        public List<CourseBrief> Courses;
        protected void Page_Load(object sender, EventArgs e)
        {
            courseBO = new CourseLogic();
            LoadCourses();
        }

        private void LoadCourses()
        {
            this.Courses = courseBO.GetDetail();
            this.DataBind();
        }
    }
}