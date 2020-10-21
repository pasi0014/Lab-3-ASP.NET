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

            // Initialize session 
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
                // Add menu elements on page load
                topMenu.Items.Add(new ListItem("Add Student Records"));
            }
            // redirect user if button is clicked
            topMenu.Click += (s, a) => Response.Redirect("AddStudentsRecord.aspx");

            displayTable();
            
        }

        protected void submitCourseInfo_Click(object sender, EventArgs e)
        {
            //Retrive course session
            List<Course> addedCourses = Session["addedCourses"] as List<Course>;

            //Initialize variables
            string cNumber = courseNumber.Text;
            string cName = courseName.Text;

            
            //Create course object
            Course course = new Course(cNumber, cName);
            //Add course object into a session
            addedCourses.Add(course);

            //clear users input
            courseNumber.Text = "";
            courseName.Text = "";

            //display table of courses
            displayTable();
            
        }

        private void displayTable()
        {
            List<Course> addedCourses = (List<Course>)Session["addedCourses"];

            string sort = Request.Params["sort"];

            if (addedCourses.Count == 0)
            {
                //Display error row if list of courses is empty
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
                    // if users adds course into a list, error row will be removed
                    for(int i = tblCourses.Rows.Count -1; i>0; i--)
                    {
                        tblCourses.Rows.RemoveAt(i);
                    }
                }
                
                if (sort == "code")
                {
                    //Sorting by course code
                    CourseComparerByID courseComparerByID = new CourseComparerByID();
                    addedCourses.Sort(courseComparerByID);
                }
                else if (sort == "title")
                {
                    //Sorting by course title 
                    CourseComparerByName courseComparerByName = new CourseComparerByName();
                    addedCourses.Sort(courseComparerByName);
                }

                foreach(Course c in addedCourses)
                {
                    //Add all elements into a table
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