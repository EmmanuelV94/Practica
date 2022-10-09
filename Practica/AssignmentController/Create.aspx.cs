using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.AssignmentController
{
    public partial class Create : System.Web.UI.Page
    {
        private AssignmentLogic assignmentBO;
        private CourseLogic courseBO;
        private StudentLogic studentBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            assignmentBO = new AssignmentLogic();
            courseBO = new CourseLogic();
            studentBO = new StudentLogic();
            if (!IsPostBack)
            {
                PopulateStudents();
                PopulateCourses();
            }
        }

        private void PopulateStudents()
        {
            this.StudentId.DataSource = studentBO.GetAll();
            this.StudentId.DataBind();
        }
        private void PopulateCourses()
        {
            this.CourseId.DataSource = courseBO.GetAll();
            this.CourseId.DataBind();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = assignmentBO.Save(Convert.ToInt32(this.StudentId.SelectedValue),
                                                 this.CourseId.SelectedValue);
        }
    }
}