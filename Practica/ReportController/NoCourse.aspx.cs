using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.ReportController
{
    public partial class NoCourse : System.Web.UI.Page
    {
        private StudentLogic studentBO;
        public List<Student> Students;

        protected void Page_Load(object sender, EventArgs e)
        {
            studentBO = new StudentLogic();
            LoadStudents();
        }

        private void LoadStudents()
        {
            this.Students = studentBO.GetWithNoCourse();
            this.DataBind();
        }
    }
}