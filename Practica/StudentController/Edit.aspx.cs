using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.StudentController
{
    public partial class Edit : System.Web.UI.Page
    {
        private StudentLogic studentBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            studentBO = new StudentLogic();
            if (!IsPostBack)
            {
                LoadStudent();
            }
        }

        private void LoadStudent()
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                if (int.TryParse(Request.QueryString["id"], out int carnet))
                {
                    var student = studentBO.Get(carnet);
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
                        this.FirstName.ReadOnly = this.SecondLastName.ReadOnly = this.LastName.ReadOnly = this.SecondLastName.ReadOnly = this.DateBirth.ReadOnly = true;
                        this.BtnSave.Enabled = false;
                        this.message = $"El estudiante con el número de carnet {carnet} no existe";
                    }
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = studentBO.Update(this.Carnet.Text,
                                                 this.FirstName.Text?.Trim(),
                                                 this.SecondName.Text?.Trim(),
                                                 this.LastName.Text?.Trim(),
                                                 this.SecondLastName.Text?.Trim(),
                                                 this.DateBirth.Text);
        }
    }
}