using Business;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Objects.Dtos;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILibraryService libraryService;
        private readonly IBusinessHelper businessHelper;

        public ReportController(ILogger<HomeController> logger, ILibraryService bookService, IBusinessHelper helper )
        {
            this.libraryService = bookService;
            this.businessHelper = helper;
        }

        public async Task<IActionResult> Index()
        {
            DailyReportDto md = await libraryService.DailyReport();
            return View(md);
        }
    }
}