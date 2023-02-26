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
        //private readonly IUserRepo _userRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepo bookRepo/*, IUserRepo userRepo*/)
        {
            _logger = logger;
            _bookRepo = bookRepo;
            //_userRepo = userRepo;
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

        public async Task<IActionResult> Search()
        {
            //List<BookModel> books = await _bookRepo.GetSearchList();
            return View(/*books*/);
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

        public async Task<IActionResult> Admin()
        {
            //List<UserModel> users = await _userRepo.getUsers();
            return View(/*users*/);
        }

        public async Task<IActionResult> AvailableInventoryListReport()
        {
            var model = new AvailableReportModel();
            model.Authors = await _bookRepo.getAuthors();
            model.Genres = await _bookRepo.getGenres();
            model.Books = new List<BookModel>();
            return View(model);
        }

        public async Task<IActionResult> ChangeHistoryReport()
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
