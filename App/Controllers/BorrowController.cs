using App.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Logged]
    public class BorrowController : Controller
    {
        BorrowService borrowService;
        BookService bookService;
        StudentService studentService;

        public BorrowController(
            BorrowService borrowService,
            BookService bookService,
            StudentService studentService)
        {
            this.borrowService = borrowService;
            this.bookService = bookService;
            this.studentService = studentService;
        }

        public IActionResult Index(string search)
        {
            var records = string.IsNullOrEmpty(search)
                ? borrowService.Get()
                : borrowService.Search(search);

            ViewBag.Search = search;
            return View(records);
        }

        [HttpGet]
        public IActionResult BorrowBook()
        {
            ViewBag.Students = studentService.Get();
            ViewBag.Books = bookService.Get()
                .Where(b => b.AvailableCopies > 0)
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult BorrowBook(BorrowRecordDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = borrowService.BorrowBook(dto);

                if (result)
                {
                    TempData["Msg"] = "Book borrowed successfully";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Book is not available";
            }

            ViewBag.Students = studentService.Get();
            ViewBag.Books = bookService.Get()
                .Where(b => b.AvailableCopies > 0)
                .ToList();

            return View(dto);
        }

        [HttpGet]
        public IActionResult ReturnBook(int id)
        {
            var record = borrowService.Get(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult ReturnConfirmed(int BorrowRecordId)
        {
            var result = borrowService.ReturnBook(BorrowRecordId);

            if (result)
            {
                TempData["Msg"] = "Book returned successfully";
            }
            else
            {
                TempData["Msg"] = "Book return failed";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Overdue()
        {
            var records = borrowService.GetOverdue();
            return View("Index", records);
        }
    }
}