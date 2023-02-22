using BestofBooks.Models;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BestofBooks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepo _bookRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepo bookRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> InventoryList()
        {
            List<BookModel> books = await _bookRepo.GetInventoryList();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult AvailableInventoryListReport()
        {
            return View();
        }

        public IActionResult ChangeHistoryReport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
