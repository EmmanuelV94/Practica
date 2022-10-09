using DAL.Model;
using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica.StudentController
{
    public partial class WebForm1 : System.Web.UI.Page
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
            this.Students = studentBO.GetAll();
            this.DataBind();
        }

        protected void dlStudents_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    Student entry = e.Item.DataItem as Student;
            //    HyperLink lnkName = e.Item.FindControl("lnkName") as HyperLink;
            //    lnkName.Text = entry.FirstName.ToString();
            //    Label lblAge = e.Item.FindControl("lblAge") as Label;
            //    lblAge.Text = entry.StudentAge.ToString();
            //}
        }
    }
}