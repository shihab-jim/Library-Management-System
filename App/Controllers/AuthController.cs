using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    
    public class AuthController : Controller
    {
        AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                var userName = authService.Login(dto);

                if (!string.IsNullOrEmpty(userName))
                {
                    HttpContext.Session.SetString("Email", dto.Email);
                    HttpContext.Session.SetString("UserName", userName);

                    TempData["Msg"] = "Login successful";
                    TempData["Class"] = "alert-success";

                    return RedirectToAction("Dashboard");
                }

                TempData["Msg"] = "Invalid email or password";
                TempData["Class"] = "alert-danger";
            }
            else
            {
                TempData["Msg"] = "Please enter valid email and password";
                TempData["Class"] = "alert-danger";
            }

            return View(dto);
        }

        public IActionResult Dashboard()
        {
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            TempData["Msg"] = "Logout successful";
            TempData["Class"] = "alert-success";

            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}