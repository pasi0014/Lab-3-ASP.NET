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
    public partial class AddStudentsRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
            btnHome.Click += (s, a) => Response.Redirect("Default.aspx");

            if (Session["addedCourses"] == null) 
            {
                Response.Redirect("AddCourse.aspx");
            }
/*            List<Student> addedStudents = null;
            if(Session["addedStudents"] == null)
            {
                addedStudents = new List<Student>();
                Session["addedStudents"] = addedStudents;
            }*/
            List<AcademicRecord> records = null;
            if(Session["records"] == null)
            {
                records = new List<AcademicRecord>();
                Session["records"] = records;
            }

            BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
            if (!IsPostBack)
            {
                topMenu.Items.Add(new ListItem("Add Course Record"));
                List<Course> addedCourses = (List<Course>)Session["addedCourses"];

                foreach(Course c in addedCourses)
                {
                    courseSelection.Items.Add(c.ToString());
                }   
            }
            
            topMenu.Click += (s, a) => Response.Redirect("AddCourse.aspx");

            displayTable();

        }

        protected void courseSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sName = studentName.Text;
            string sNumber = studentNumber.Text;
            string sGrade = grade.Text;
            List<Course> addedCourses = (List<Course>)Session["addedCourses"];
            List<AcademicRecord> records = (List<AcademicRecord>)Session["records"];
            if (!IsPostBack)
            {
                if (courseSelection.SelectedValue != "0")
                {
                    Course selectedCourse = addedCourses[courseSelection.SelectedIndex - 1];

                    for (int i = 0; i < records.Count; i++)
                    {
                        if (selectedCourse.CourseNumber == records[i].Course.CourseNumber)
                        {
                            TableCell c1 = new TableCell();
                            c1.Text = string.Concat(records[i].Student.Id);

                            TableCell c2 = new TableCell();
                            c2.Text = string.Concat(records[i].Student.Name);

                            TableRow row = new TableRow();

                            row.Controls.Add(c1);
                            row.Controls.Add(c2);

                            tblStudents.Controls.Add(row);
                        }

                    }

                }
            }
            

        }

        protected void btnAddstudentRecord_Click(object sender, EventArgs e)
        {
            string sName = studentName.Text;
            string sNumber = studentNumber.Text;
            int sGrade = int.Parse(grade.Text);

            List<Course> addedCourses = (List<Course>)Session["addedCourses"];

            List<AcademicRecord> records = (List<AcademicRecord>)Session["records"];

            AcademicRecord record = null;

            Student student = new Student(sNumber, sName);

            foreach (Course course in addedCourses)
            {
                Course c = new Course(course.CourseNumber, course.CourseName);
                record = new AcademicRecord(c, student);

            }
            record.Grade = sGrade;
            records.Add(record);



            studentName.Text = "";
            studentNumber.Text = "";
            grade.Text = "";

            /*displayTable();*/

        }
        private void displayTable()
        {

            List<AcademicRecord> records = (List<AcademicRecord>)Session["records"];
            /*string sGrade = grade.Text;*/
            if(records.Count == 0)
            {
                TableRow errorRow = new TableRow();
                TableCell errorCell = new TableCell();
                errorCell.Text = "No Student Record Exist!";
                errorCell.Style["color"] = "red";
                errorCell.ColumnSpan = 3;
                errorCell.HorizontalAlign = HorizontalAlign.Center;
                errorRow.Cells.Add(errorCell);
                tblStudents.Controls.Add(errorRow);
            }
            else
            {
                if(tblStudents.Rows.Count > 1)
                {
                    for(int i = tblStudents.Rows.Count - 1; i > 0; i--)
                    {
                        tblStudents.Rows.RemoveAt(i);
                    }
                }


                foreach (AcademicRecord s in records)
                {
                    TableCell c1 = new TableCell();
                    c1.Text = string.Concat(s.Student.Id);

                    TableCell c2 = new TableCell();
                    c2.Text = string.Concat(s.Student.Name);

                    TableCell c3 = new TableCell();
                    c3.Text = string.Concat(s.Grade);

                    TableRow row = new TableRow();
                    row.Controls.Add(c1);
                    row.Controls.Add(c2);
                    row.Controls.Add(c3);

                    tblStudents.Controls.Add(row);
                }
            }
        }
    }
}