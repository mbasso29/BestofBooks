using BestofBooks.Models;
using BestofBooks.Repo;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserRepo _userRepo;

        public HomeController(ILogger<HomeController> logger, IBookRepo bookRepo, IUserRepo userRepo)
        {
            _logger = logger;
            _bookRepo = bookRepo;
            _userRepo = userRepo;
        }

        public async Task<IActionResult> InventoryList()
        {
            List<BookModel> books = await _bookRepo.GetInventoryList();
            var model = new InventoryListViewModel { invListBooks = books,User = loggedInUser };
            return View(model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel { User= loggedInUser };
            return View(model);
        }

        public async Task<IActionResult> Search()
        {
            List<BookModel> books = await _bookRepo.GetSearchList();  // remove empty space when table isn't shown
            var model = new InventoryListViewModel { invListBooks = books, User = loggedInUser };
            return View(model);
        }

        public IActionResult Reports()
        {
            var model = new BaseViewModel { User = loggedInUser };
            return View(model);
        }

        public IActionResult CreateAccount()
        {
            var model = new BaseViewModel {User = loggedInUser};
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(UserModel model)
        {
            model.password = SecurityUtilities.HashPassword(model.password);
            model.is_ViewOnly = true;
            _userRepo.createUser(model);
            var emptyModel = new BaseViewModel { User = loggedInUser };
            return View(emptyModel);
        }

        public async Task<IActionResult> Admin()
        {
            List<UserModel> admins = await _userRepo.getUsers();
            var model = new UserViewModel { User = loggedInUser, listUsers = admins };
            return View(model);
        }

        public async Task<IActionResult> AvailableInventoryListReport()
        {
            var model = new AvailableReportModel();
            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.listBooks = new List<BookModel>();
            return View(model);
        }

        public async Task<IActionResult> ChangeHistoryReport()
        {
            var model = new UserViewModel();
            model.chUserNames = await _userRepo.getUserNames();
            model.chUserLast = await _userRepo.getUserLastNames();
            model.listUsers= new List<UserModel>();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private bool isUserLoggedIn => this.HttpContext.Session.GetInt32("_loggedInUser") != 0;

        private UserModel loggedInUser => _userRepo.getUsers().Result.FirstOrDefault(u => u.BoBuser_id == this.HttpContext.Session.GetInt32("_loggedInUser"));
    }
}
