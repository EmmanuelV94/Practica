using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.CourseController
{
    public partial class Create : System.Web.UI.Page
    {
        private CourseLogic courseBO;
        private TeacherLogic teacherBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            courseBO = new CourseLogic();
            teacherBO = new TeacherLogic();
            if (!IsPostBack)
            {
                PopulateTeachers();
            }
        }

        private void PopulateTeachers()
        {
            var teachers = teacherBO.GetAll();
            teachers.Add(new DAL.Model.Teacher
            {
                Carnet = 0,
                FirstName = "Sin asignar"
            });
            this.TeacherId.DataSource = teachers.OrderBy(x => x.Carnet).ToList();
            this.TeacherId.DataBind();
            this.TeacherId.SelectedValue = "0";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = courseBO.Save(this.Code.Text,
                                                 this.Name.Text?.Trim(),
                                                 this.Description.Text?.Trim(),
                                                 this.TeacherId.SelectedValue?.Trim());
        }
    }
}