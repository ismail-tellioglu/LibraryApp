using Business;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Objects.Dtos;
using System.Diagnostics;

namespace LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILibraryService libraryService;
        private readonly IBusinessHelper businessHelper;

        public HomeController(ILogger<HomeController> logger, ILibraryService bookService, IBusinessHelper helper )
        {
            _logger = logger;
            this.libraryService = bookService;
            this.businessHelper = helper;
        }

        public IActionResult Index()
        {
            return View(new BookSearchDto());
        }

        [HttpPost]
        public async Task<IActionResult> SearchBooks(BookSearchDto criterias)
        {
            var result = await libraryService.SearchBooks(criterias);
            return PartialView("~/Views/Shared/_SearchResult.cshtml",result);
        }

        public async Task<IActionResult> CheckOut(string isdn)
        {
            var md = new CheckOutDto { ISDNToCeheckOut = isdn,
                EndDate=businessHelper.CalculateDateAccordingToWorkDays(DateTime.Now,30),
                StartDate=DateTime.Now};
            return PartialView("~/Views/Shared/_CheckOut.cshtml", md);
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckOutDto md)
        {
            var result = await libraryService.CheckOut(md);
            if (result == "Success")
                return Ok();
            else
                return BadRequest(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}