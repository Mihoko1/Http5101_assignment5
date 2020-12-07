﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Http5101_assignment5.Models;
using MySql.Data.MySqlClient;

namespace Http5101_assignment5.Controllers
{
    public class StudentDataController : ApiController
    {
        // Student class allows to access MySQL Database. 
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller will access to students table.
        /// <summary>
        /// Returns a list of Students
        /// </summary>
        /// <example>GET api/StudentData/ListStudents</example>
        /// <returns>
        /// A list of students (student id, student first name, student last name, student number)
        /// </returns>
        [HttpGet]
        public IEnumerable<Student> ListStudents()
        {

            // Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // Query
            cmd.CommandText = "select * from students";

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Create an empty list of Students 
            List<Student> Students = new List<Student> { };

            // Loop through each row of ResultSet (from database)
            while (ResultSet.Read())
            {

                uint StudentId = (uint)ResultSet["studentid"];
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];

                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;

                Students.Add(NewStudent);

            }
            Conn.Close();

            return Students;
        }

        //This Controller will access to students table.
        /// <summary>
        /// Returns student data which student id is matching with parameter.
        /// </summary>
        /// <example>GET api/StudentData/FindStudent/{id}</example>
        /// <returns> 
        /// student data (student id, student number, student first name, student last name, enroll date)
        /// </returns>
        [HttpGet]
        public Student FindStudent(int id)
        {
            Student NewStudent = new Student();

            // Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            // Open the connection between the web server and database
            Conn.Open();

            // Establish a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            // Query
            cmd.CommandText = "select * from students where studentid = " + id;

            // Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Loop through each row of ResultSet (from database)
            while (ResultSet.Read())
            {

                uint StudentId = (uint)ResultSet["studentid"];
                string StudentFname = (string)ResultSet["studentfname"];
                string StudentLname = (string)ResultSet["studentlname"];
                string StudentNumber = (string)ResultSet["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultSet["enroldate"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;

            }

            return NewStudent;
        }
    }
}
