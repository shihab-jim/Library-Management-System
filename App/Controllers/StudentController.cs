using App.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Logged]
    public class StudentController : Controller
    {
        StudentService studentService;

        public StudentController(StudentService studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult Index(string search)
        {
            var students = string.IsNullOrEmpty(search)
                ? studentService.Get()
                : studentService.Search(search);

            ViewBag.Search = search;
            return View(students);
        }

        public IActionResult Details(int id)
        {
            var student = studentService.Get(id);
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = studentService.Create(dto);

                if (result)
                {
                    TempData["Msg"] = "Student created successfully";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Email or Student No already exists";
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentService.Get(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(StudentDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = studentService.Update(dto);

                if (result)
                {
                    TempData["Msg"] = "Student updated successfully";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Email or Student No already exists";
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentService.Get(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int StudentId)
        {
            var result = studentService.Delete(StudentId);

            if (result)
            {
                TempData["Msg"] = "Student deleted successfully";
            }
            else
            {
                TempData["Msg"] = "Student delete failed. This student may have borrow records.";
            }

            return RedirectToAction("Index");
        }
    }
}