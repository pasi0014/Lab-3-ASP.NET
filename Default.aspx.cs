using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
            BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");

            if (!IsPostBack)
            {
                

                topMenu.Items.Add(new ListItem("Add Course"));
                topMenu.Items.Add(new ListItem("Add Student"));

                
                
            }
            topMenu.Click += topMenu_Click;
        }

        protected void topMenu_Click(object sender, BulletedListEventArgs e)
        {
            switch (e.Index)
            {
                case 0:
                    Response.Redirect("AddCourse.aspx");
                    break;
                case 1:
                    Response.Redirect("AddStudentsRecord.aspx");
                    break;
                default:
                    break;
            }
        }
    }
}