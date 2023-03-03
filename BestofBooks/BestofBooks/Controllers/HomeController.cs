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
            List<BookModel> books = await _bookRepo.GetInventoryList();  //change user rights for trashcan and editable content
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search()
        {
            List<BookModel> books = await _bookRepo.GetSearchList();  // remove empty space when table isn't shown
            return View(books);
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(UserModel model)
        {
            model.password = SecurityUtilities.HashPassword(model.password);
            model.is_ViewOnly = true;
            _userRepo.createUser(model);
            return View();
        }

        public async Task<IActionResult> Admin()
        {
            List<UserModel> users = await _userRepo.getUsers();
            return View(users);
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
            //List<UserModel> users = await _userRepo.getChangeHistory();    //throws error
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<bool> loginUser(string userName, string password)
        {
            List<UserModel> users = await _userRepo.getUsers();
            var user = users.FirstOrDefault(u => u.username.ToLower() == userName.ToLower());
            if (user == null)
            {
                return false;
            }
            bool success = SecurityUtilities.userLoggedIn(user.password, password);
            if (success)
            {
                this.HttpContext.Session.SetInt32("_loggedInUser",user.BoBuser_id);
            }
            else
            {
                this.HttpContext.Session.SetInt32("_loggedInUser", 0);
            }
            return success;
        }

        private bool isUserLoggedIn => this.HttpContext.Session.GetInt32("_loggedInUser") != 0;

        private UserModel loggedInUser => _userRepo.getUsers().Result.FirstOrDefault(u => u.BoBuser_id == this.HttpContext.Session.GetInt32("_loggedInUser"));
    }
}
