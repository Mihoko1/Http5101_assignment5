using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Http5101_assignment5.Models
{
    public class Teacher
    {
        // The following fields define an Teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;
        public string ClassCode;
        public string ClassName;

        //Parameter-less constructor function
        public Teacher() { }
    }
}