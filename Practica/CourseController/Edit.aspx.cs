using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.CourseController
{
    public partial class Edit : System.Web.UI.Page
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
                LoadCourse();
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

        private void LoadCourse()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                var course = courseBO.Get(Request.QueryString["id"]);
                if (course != null)
                {
                    this.Code.Text = course.Code;
                    this.Name.Text = course.Name;
                    this.Description.Text = course.Description;
                    if (course.TeacherId.HasValue)
                        this.TeacherId.SelectedValue = course.TeacherId.Value.ToString();
                }
                else
                {
                    this.Code.ReadOnly = this.Name.ReadOnly = this.Description.ReadOnly = true;
                    this.BtnSave.Enabled = this.TeacherId.Enabled = false;
                    this.message = $"El curso con el código {Request.QueryString["id"]} no existe";
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = courseBO.Update(this.Code.Text,
                                                 this.Name.Text?.Trim(),
                                                 this.Description.Text?.Trim(),
                                                 this.TeacherId.SelectedValue?.Trim());
        }
    }
}