using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.AssignmentController
{
    public partial class Delete : System.Web.UI.Page
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
                LoadAssignment();
            }
        }
        private void LoadAssignment()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["studentId"]) && !string.IsNullOrWhiteSpace(Request.QueryString["courseId"]))
            {
                var assignment = assignmentBO.Get(Convert.ToInt32(Request.QueryString["studentId"]), Request.QueryString["courseId"]);
                if (assignment != null)
                {
                    this.StudentId.SelectedValue = assignment.StudentId.ToString();
                    this.CourseId.SelectedValue = assignment.CourseId;
                }
                else
                {
                    this.BtnSave.Enabled = false;
                    this.message = $"Ya no existe dicha asignación";
                }
            }
            else
            {
                this.BtnSave.Enabled = false;
                this.message = $"Ya no existe dicha asignación";
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
            this.message = assignmentBO.Delete(Convert.ToInt32(this.StudentId.SelectedValue),
                                                 this.CourseId.SelectedValue);
        }
    }
}