using DAL.Model;
using Logic;
using System.Collections.Generic;
using System;

namespace Practica.CourseController
{
    public partial class Index : System.Web.UI.Page
    {
        private CourseLogic courseBO;
        public List<Course> Courses;
        protected void Page_Load(object sender, EventArgs e)
        {
            courseBO = new CourseLogic();
            LoadCourses();
        }

        private void LoadCourses()
        {
            this.Courses = courseBO.GetAll();
            this.DataBind();
        }
    }
}