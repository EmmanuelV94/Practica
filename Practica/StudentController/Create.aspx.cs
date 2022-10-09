using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.StudentController
{
    public partial class Create : System.Web.UI.Page
    {
        private StudentLogic studentBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            studentBO = new StudentLogic();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = studentBO.Save(this.Carnet.Text,
                                                 this.FirstName.Text?.Trim(),
                                                 this.SecondName.Text?.Trim(),
                                                 this.LastName.Text?.Trim(),
                                                 this.SecondLastName.Text?.Trim(),
                                                 this.DateBirth.Text);
        }
    }
}