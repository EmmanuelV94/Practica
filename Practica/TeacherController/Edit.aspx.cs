using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.TeacherController
{
    public partial class Edit : System.Web.UI.Page
    {
        private TeacherLogic teacherBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            teacherBO = new TeacherLogic();
            if (!IsPostBack)
            {
                LoadTeacher();
            }
        }

        private void LoadTeacher()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                if (int.TryParse(Request.QueryString["id"], out int carnet))
                {
                    var teacher = teacherBO.Get(carnet);
                    if (teacher != null)
                    {
                        this.Carnet.Text = carnet.ToString();
                        this.FirstName.Text = teacher.FirstName;
                        this.SecondName.Text = teacher.SecondName;
                        this.LastName.Text = teacher.LastName;
                        this.SecondLastName.Text = teacher.SecondLastName;
                        this.DateBirth.Text = teacher.DateBirth.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        this.FirstName.ReadOnly = this.SecondLastName.ReadOnly = this.LastName.ReadOnly = this.SecondLastName.ReadOnly = this.DateBirth.ReadOnly = true;
                        this.BtnSave.Enabled = false;
                        this.message = $"El maestro con el número de carnet {carnet} no existe";
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = teacherBO.Update(this.Carnet.Text,
                                                 this.FirstName.Text?.Trim(),
                                                 this.SecondName.Text?.Trim(),
                                                 this.LastName.Text?.Trim(),
                                                 this.SecondLastName.Text?.Trim(),
                                                 this.DateBirth.Text);
        }
    }
}