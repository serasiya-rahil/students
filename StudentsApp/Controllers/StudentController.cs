/* Author: Rahil Serasiya, ID: 8899516, Section-2
 * Program: Microsoft Web Technologies
 * Computer Application Development
 * Professor: Manny Singh
 */

using FoodBasketApp.Entities;
using FoodBasketApp.Services;
using Microsoft.AspNetCore.Mvc;
using StudentsApp.Models;

namespace FoodBasketApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Get the students based on the the status or empty status meaning All students
        [HttpGet("/student/{status?}")]
        public IActionResult Items(string status)
        {
            ICollection<Student> students;

            //check for the status if NULL or all 
            if (string.IsNullOrEmpty(status) || status == "All")
            {
                //If True then return all student
                students = _studentService.GetAllStudents().ToList();

                //Update the status to All
                status = "All";
            }
            else
            {
                //if not All or NULL then get students by the status
                students = _studentService.GetStudentsByStatus(status);
            }

            // return the studentView Model to the the List view along with the Empty Student obj for adding new student
            StudentViewModel studentViewModel = new StudentViewModel()
            {

                Status = _studentService.GetAllStatuses(),
                ActiveStatus = status,
                Students = students,
                Student = new Student(),
            };

            return View("Items", studentViewModel);
        }

        //Add a New Student to in-memory collection
        [HttpPost("/student/create")]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                //Assign the next available ID to the student
                student.Id = _studentService.GetNextId();

                //Add a Student in _studentService which is in-memory collection
                _studentService.AddStudent(student);

                return RedirectToAction("Items");
            }

            StudentViewModel studentViewModel = new StudentViewModel();

            // If validation fails, reload statuses and return to Items view with validation errors
            studentViewModel.Status = _studentService.GetAllStatuses();
            studentViewModel.Students = _studentService.GetAllStudents().ToList();

            return View("Items", studentViewModel);
        }

    }
}
