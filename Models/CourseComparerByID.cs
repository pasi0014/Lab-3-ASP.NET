using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlgonquinCollege.Registration.Entities;

namespace Lab_3.Models
{
    public class CourseComparerByID : IComparer<Course>
    {
        public CourseComparerByID()
        {

        }

        public int Compare(Course c1 , Course c2)
        {
            if(c1 == null)
            {
                throw new ArgumentNullException("c1");
            }
            if(c2 == null)
            {
                throw new ArgumentNullException("c2");
            }

            if(c1.CourseNumber.CompareTo(c2.CourseNumber) != 0)
            {
                return c1.CourseNumber.CompareTo(c2.CourseNumber);
            }
            else
            {
                CourseComparerByName courseComparerByName = new CourseComparerByName();
                return courseComparerByName.Compare(c1, c2);
            }
        }

    }
}