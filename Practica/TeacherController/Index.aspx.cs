using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.TeacherController
{
    public partial class Index : System.Web.UI.Page
    {
        private TeacherLogic teacherBO;
        public List<Teacher> Teachers;
        protected void Page_Load(object sender, EventArgs e)
        {
            teacherBO = new TeacherLogic();
            LoadTeachers();
        }

        private void LoadTeachers()
        {
            this.Teachers = teacherBO.GetAll();
            this.DataBind();
        }
    }
}