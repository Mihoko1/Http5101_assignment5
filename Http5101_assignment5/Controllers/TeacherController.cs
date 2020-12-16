using Http5101_assignment5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


namespace Http5101_assignment5.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        // GET: /Teacher/List
        public ActionResult List(string Searchkey = null)
        {

            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(Searchkey);

            return View(Teachers);

        }

        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        // GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        // POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {

            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            // When a teacher data is deleted, redirect to List page
            return RedirectToAction("List");
        }

        // GET: /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        // POST: /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber,
            DateTime HireDate, decimal Salary)
        {


            //Identify that this method is running 
            //Identify the inputs provided from the form

            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);
            Debug.WriteLine(Salary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = HireDate;
            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            //When new data is created, redirect to List page
            return RedirectToAction("List");


        }
        //Get: /Teacher/Update/{id}
        /// <summary>
        /// Receive a POST reqiest containing information about an existing teacher in the system, with new values.
        /// Conveys this information to the API, and redirects to the Teacher's "Show" page
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The update first name of the teacher</param>
        /// <param name="TeacherLname">The update last name of the teacher</param>
        /// <param name="EmployeeNumber">The update employee number of the teacher</param>
        /// <param name="HireDate">The update first hire date of the teacher</param>
        /// <param name="Salary">The update salaryof the teacher</param>
        /// <returns></returns>

        public ActionResult Update(int id)
        {

            TeacherDataController controller = new TeacherDataController();
            Teacher SelectTeacher = controller.FindTeacher(id);

            return View(SelectTeacher);
        }

        //POST: Teacher/Update/{id}
        /// <summary>
        /// Receive a POST reqiest containing information about an existing teacher in the system, with new values.
        /// Conveys this information to the API, and redirects to the Teacher's "Show" page
        /// </summary>
        /// <param name="id">Id of the Teacher to update</param>
        /// <param name="TeacherFname">The update first name of the teacher</param>
        /// <param name="TeacherLname">The update last name of the teacher</param>
        /// <param name="EmployeeNumber">The update employee number of the teacher</param>
        /// <param name="HireDate">The update first hire date of the teacher</param>
        /// <param name="Salary">The update salaryof the teacher</param>
        /// <returns>A dynamic webpage which provides the current infromation of the author.</returns>
        /// 
        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber,
            DateTime HireDate, decimal Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.HireDate = HireDate;
            TeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);


            return RedirectToAction("Show/" + id);
        }


    }
}