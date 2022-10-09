using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.TeacherController
{
    public partial class Delete : System.Web.UI.Page
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
                    var student = teacherBO.Get(carnet);
                    if (student != null)
                    {
                        this.Carnet.Text = carnet.ToString();
                        this.FirstName.Text = student.FirstName;
                        this.SecondName.Text = student.SecondName;
                        this.LastName.Text = student.LastName;
                        this.SecondLastName.Text = student.SecondLastName;
                        this.DateBirth.Text = student.DateBirth.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        this.BtnSave.Enabled = false;
                        this.message = $"El estudiante con el número de carnet {carnet} no existe";
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = teacherBO.Delete(this.Carnet.Text);
        }
    }
}