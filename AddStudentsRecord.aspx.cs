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

            //if session of added Courses is empty user will be redirected to AddCourse page
            if (Session["addedCourses"] == null) 
            {
                Response.Redirect("AddCourse.aspx");
            }
            //initializing list of objects 
            List<AcademicRecord> records = null;
            //Initializing session records
            if(Session["records"] == null)
            {
                records = new List<AcademicRecord>();
                Session["records"] = records;
            }
            BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");
            if (!IsPostBack)
            {
                topMenu.Items.Add(new ListItem("Add Course Record"));
                //Retrieving session of added Courses
                List<Course> addedCourses = (List<Course>)Session["addedCourses"];
                //Adding course objects into a dropDown list
                foreach(Course c in addedCourses)
                {
                    courseSelection.Items.Add(c.ToString());
                }   
            }
            
            topMenu.Click += (s, a) => Response.Redirect("AddCourse.aspx");

            /*displayTable();*/

        }

        protected void courseSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieving Academic Records session
            List<AcademicRecord> records = (List<AcademicRecord>)Session["records"];


            if (IsPostBack)
            {
                if (courseSelection.SelectedValue != "0")
                {
                    if(records.Count != 0)
                    {
                        for (int i = 0; i < records.Count; i++)
                        {
                            if (courseSelection.SelectedValue == records[i].Course.ToString())
                            {
                                //Display related students to selected course
                                TableCell c1 = new TableCell();
                                c1.Text = string.Concat(records[i].Student.Id);

                                TableCell c2 = new TableCell();
                                c2.Text = string.Concat(records[i].Student.Name);

                                TableCell c3 = new TableCell();
                                c3.Text = string.Concat(records[i].Grade);

                                TableRow row = new TableRow();
                                row.Controls.Add(c1);
                                row.Controls.Add(c2);
                                row.Controls.Add(c3);

                                tblStudents.Controls.Add(row);

                            }
                            
                        }
                    }
                    else
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



                }

            }
        }

        protected void btnAddstudentRecord_Click(object sender, EventArgs e)
        {
            //Initializing variables
            string sName = studentName.Text;
            string sNumber = studentNumber.Text;
            int sGrade = int.Parse(grade.Text);
            //Retrieving session for added Courses 
            List<Course> addedCourses = (List<Course>)Session["addedCourses"];
            //Retrieving session for Academic Records
            List<AcademicRecord> records = (List<AcademicRecord>)Session["records"];

            AcademicRecord record = null;
            //getting course object from course selection
            Course selectedCourse = addedCourses[courseSelection.SelectedIndex - 1];
            
            if (courseSelection.SelectedValue == selectedCourse.ToString())
            {
                //Initializing selected course object
                Course course = new Course(selectedCourse.CourseNumber, selectedCourse.CourseName);
                //Initializing student object
                Student student = new Student(sNumber, sName);
                //Initializing Academic Record object
                record = new AcademicRecord(course, student);
                //Getting grade 
                record.Grade = sGrade;
                //adding academic record object into a session list
                records.Add(record);
                

                //Displaying Table of added students 
                foreach (AcademicRecord r in records)
                {
                    if (courseSelection.SelectedValue == r.Course.ToString())
                    {
                        TableCell c1 = new TableCell();
                        c1.Text = string.Concat(r.Student.Id);

                        TableCell c2 = new TableCell();
                        c2.Text = string.Concat(r.Student.Name);

                        TableCell c3 = new TableCell();
                        c3.Text = string.Concat(r.Grade);

                        TableRow row = new TableRow();
                        row.Controls.Add(c1);
                        row.Controls.Add(c2);
                        row.Controls.Add(c3);

                        tblStudents.Controls.Add(row);
                    }
                }
            }


            // Clearing text inputs 
            studentName.Text = "";
            studentNumber.Text = "";
            grade.Text = "";

        }
       
            

        
    }
}