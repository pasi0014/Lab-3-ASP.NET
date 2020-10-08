using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlgonquinCollege.Registration.Entities;
using Lab_3.Models;


namespace Lab_3
{
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Course> addedCourses = null;

            if (Session["addedCourses"] == null) 
            {
                addedCourses = new List<Course>();
                Session["addedCourses"] = addedCourses;
            }
            else
            {
                addedCourses = (List<Course>)Session["addedCourses"];
            }


            LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
            btnHome.Click += (s, a) => Response.Redirect("Default.aspx");

            BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
            if (!IsPostBack)
            {
                topMenu.Items.Add(new ListItem("Add Student Records"));
            }
            topMenu.Click += (s, a) => Response.Redirect("AddStudentsRecord.aspx");

            displayTable();
            
        }

        protected void submitCourseInfo_Click(object sender, EventArgs e)
        {
            List<Course> addedCourses = Session["addedCourses"] as List<Course>;

            string cNumber = courseNumber.Text;
            string cName = courseName.Text;

            

            Course course = new Course(cNumber, cName);
            addedCourses.Add(course);

            courseNumber.Text = "";
            courseName.Text = "";

            displayTable();
            
        }

        private void displayTable()
        {
            List<Course> addedCourses = (List<Course>)Session["addedCourses"];

            string sort = Request.Params["sort"];

            if (addedCourses.Count == 0)
            {
                TableRow errorRow = new TableRow();
                TableCell errorCell = new TableCell();
                errorCell.Text = "No Course Record Exist!";
                errorCell.Style["color"] = "red";
                errorCell.ColumnSpan = 3;
                errorCell.HorizontalAlign = HorizontalAlign.Center;
                errorRow.Cells.Add(errorCell);
                tblCourses.Controls.Add(errorRow);
            }
            else
            {
                if(tblCourses.Rows.Count > 1)
                {
                    for(int i = tblCourses.Rows.Count -1; i>0; i--)
                    {
                        tblCourses.Rows.RemoveAt(i);
                    }
                }
                
                if (sort == "code")
                {
                    CourseComparerByID courseComparerByID = new CourseComparerByID();
                    addedCourses.Sort(courseComparerByID);
                }
                else if (sort == "title")
                {
                    CourseComparerByName courseComparerByName = new CourseComparerByName();
                    addedCourses.Sort(courseComparerByName);
                }

                foreach(Course c in addedCourses)
                {
                    TableCell c1 = new TableCell();
                    c1.Text = string.Concat(c.CourseNumber);

                    TableCell c2 = new TableCell();
                    c2.Text = string.Concat(c.CourseName);

                    TableRow row = new TableRow();
                    row.Controls.Add(c1);
                    row.Controls.Add(c2);

                    tblCourses.Controls.Add(row);
                }

            }
        }
    }

}