using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.AssignmentController
{
    public partial class Index : System.Web.UI.Page
    {
        private AssignmentLogic assignmentBO;
        public List<CourseAssignment> Assignments;
        protected void Page_Load(object sender, EventArgs e)
        {
            assignmentBO = new AssignmentLogic();
            LoadCourses();
        }

        private void LoadCourses()
        {
            this.Assignments = assignmentBO.GetAll();
            this.DataBind();
        }
    }
}