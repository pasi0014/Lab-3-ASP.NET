using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgonquinCollege.Registration.Entities;

namespace Lab_3.Models
{
    public class CourseComparerByName : IComparer<Course>
    {
        public CourseComparerByName()
        {

        }

        public int Compare(Course c1, Course c2)
        {
            if (c1 == null)
            {
                throw new ArgumentNullException("c1");
            }
            if (c2 == null)
            {
                throw new ArgumentNullException("c2");
            }

            string cName1 = c1.CourseName.Split(' ')[0];

            string cName2 = c2.CourseName.Split(' ')[0];

            if(cName1.CompareTo(cName2) != 0)
            {
                return cName1.CompareTo(cName2);
            }

            return c1.CourseNumber.CompareTo(c2.CourseNumber);
        }
    }
}