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
        private readonly IBookService bookService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(new BookSearchDto());
        }

        [HttpPost]
        public IActionResult SearchBooks(BookSearchDto criterias)
        {
            var result = bookService.SearchBooks(criterias);
            return PartialView("~/Views/Shared/_SearchResult.cshtml",result);
        }

        public IActionResult CheckOut(string isdn)
        {
            var md = new CheckOutDto { ISDNToCeheckOut = isdn };
            return PartialView("~/Views/Shared/_CheckOut.cshtml", md);
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutDto md)
        {
            var result = bookService.CheckOut(md).Result;
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