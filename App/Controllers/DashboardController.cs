using App.AuthFilter;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Logged]
    public class DashboardController : Controller
    {
        ReportService reportService;

        public DashboardController(ReportService reportService)
        {
            this.reportService = reportService;
        }

        public IActionResult Index()
        {
            var data = reportService.GetDashboard();
            return View(data);
        }
    }
}