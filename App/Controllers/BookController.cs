using App.AuthFilter;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Logged]
    public class BookController : Controller
    {
        BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index(string search)
        {
            var books = string.IsNullOrEmpty(search)
                ? bookService.Get()
                : bookService.Search(search);

            ViewBag.Search = search;
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = bookService.Create(dto);

                if (result)
                {
                    TempData["Msg"] = "Book created successfully";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "ISBN already exists or available copies cannot be greater than total copies";
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookDTO dto)
        {
            if (ModelState.IsValid)
            {
                var result = bookService.Update(dto);

                if (result)
                {
                    TempData["Msg"] = "Book updated successfully";
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "ISBN already exists or available copies cannot be greater than total copies";
            }

            return View(dto);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = bookService.Get(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int BookId)
        {
            var result = bookService.Delete(BookId);

            if (result)
            {
                TempData["Msg"] = "Book deleted successfully";
            }
            else
            {
                TempData["Msg"] = "Book delete failed. This book may have borrow records.";
            }

            return RedirectToAction("Index");
        }
    }
}