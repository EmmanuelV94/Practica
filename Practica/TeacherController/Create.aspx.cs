using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.TeacherController
{
    public partial class Create : System.Web.UI.Page
    {
        private TeacherLogic teacherBO;
        public string message;
        protected void Page_Load(object sender, EventArgs e)
        {
            teacherBO = new TeacherLogic();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            this.message = teacherBO.Save(this.Carnet.Text,
                                                 this.FirstName.Text?.Trim(),
                                                 this.SecondName.Text?.Trim(),
                                                 this.LastName.Text?.Trim(),
                                                 this.SecondLastName.Text?.Trim(),
                                                 this.DateBirth.Text);
        }
    }
}