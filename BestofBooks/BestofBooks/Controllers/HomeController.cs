using BestofBooks.Models;
using BestofBooks.Models.ViewModels;
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
            var model = new InventoryListViewModel
            {
                invListBooks = books,
                LoggedInUser = loggedInUser,
                newBook = new BookModel()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InventoryList(InventoryListViewModel model)
        {
            await _bookRepo.CreateBook(model.newBook);

            List<BookModel> books = await _bookRepo.GetInventoryList();
            model.invListBooks = books;
            model.LoggedInUser = loggedInUser;
            model.newBook = new BookModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> InventoryListUpdate(InventoryListViewModel model)
        {
            await _bookRepo.EditBook(model.editBook);

            List<BookModel> books = await _bookRepo.GetInventoryList();
            model.invListBooks = books;
            model.LoggedInUser = loggedInUser;
            model.newBook = new BookModel();
            return View("InventoryList", model);
        }

        public IActionResult Privacy()
        {
            var model = new BaseViewModel { LoggedInUser = loggedInUser };
            return View(model);
        }

        public IActionResult Search()
        {
            var model = new SearchViewModel { LoggedInUser = loggedInUser, Results = new List<BookModel>()};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel model)
        {
            var books = await _bookRepo.GetInventoryList();
            switch (model.FilterType)
            {
                case "Genre":
                    books = books.Where(b => b.Genre == model.Query).ToList();
                    break;
                case "LastName":
                    books = books.Where(b => b.AuthorLast == model.Query).ToList();
                    break;
                case "FirstName":
                    books = books.Where(b => b.AuthorFirst == model.Query).ToList();
                    break;
                case "Title":
                    books = books.Where(b => b.Title == model.Query).ToList();
                    break;
                default:
                    books = new List<BookModel>();
                    break;
            }

            model.Results = books;
            return View(model);
        }

        public IActionResult Reports()
        {
            var model = new BaseViewModel { LoggedInUser = loggedInUser };
            return View(model);
        }

        public IActionResult CreateAccount()
        {
            var model = new CreateAccountViewModel { LoggedInUser = loggedInUser, UserToCreate = new UserModel() };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(CreateAccountViewModel model)
        {
            model.UserToCreate.password = SecurityUtilities.HashPassword(model.UserToCreate.password);
            model.UserToCreate.is_ViewOnly = true;
            _userRepo.createUser(model.UserToCreate);
            var emptyModel = new CreateAccountViewModel { LoggedInUser = loggedInUser, UserToCreate = new UserModel() };
            return View(emptyModel);
        }

        public async Task<IActionResult> Admin()
        {
            List<UserModel> admins = await _userRepo.getUsers();
            var model = new UserViewModel { LoggedInUser = loggedInUser, listUsers = admins };
            return View(model);
        }

        public async Task<IActionResult> AvailableInventoryListReport()
        {
            var model = new AvailableReportViewModel();
            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.listBooks = new List<BookModel>();
            model.bookFilters = new BookFilters();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AvailableInventoryListReport(AvailableReportViewModel model)
        {
            model.bookAuthors = await _bookRepo.getAuthors();
            model.bookGenres = await _bookRepo.getGenres();
            model.bookFilters = new BookFilters();

            var filteredList = await _bookRepo.GetSearchList();
            model.listBooks = filteredList
                .Where(b => model.bookFilters.Genre == null || b.Genre == model.bookFilters.Genre)
                .Where(b => model.bookFilters.Author == null || b.AuthorFullName == model.bookFilters.Author)
                .Where(b => model.bookFilters.Stock == null || model.bookFilters.Stock == "All" || (model.bookFilters.Stock == "instock" && b.InStock) || (model.bookFilters.Stock == "outofstock" && !b.InStock))
                .ToList();

            model.listBooks = filteredList;
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

        public IActionResult Logout()
        {
            this.HttpContext.Session.SetInt32("_loggedInUser", 0);
            return RedirectToAction("InventoryList");
        }

        private bool isUserLoggedIn => this.HttpContext.Session.GetInt32("_loggedInUser") != 0;
        private UserModel loggedInUser => _userRepo.getUsers().Result.FirstOrDefault(u => u.BoBuser_id == this.HttpContext.Session.GetInt32("_loggedInUser"));
    }
}
