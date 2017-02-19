using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public BooksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
            return View(books);
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create Book";
            var publishers = _context.Publishers.ToList();
            var authors = _context.Authors.ToList();
            var bvm = new BookViewModel
            {
                Publishers = new SelectList(publishers, "Id", "Name"),
                Authors =new SelectList(authors, "Id", "Name")
            };
            return View(bvm);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bvm)
        {
            var identity = (ClaimsIdentity) User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var user = claims?.First();
            var userId = user?.Value;

            var book = new Book()
            {
                Title = bvm.Title, 
                AuthorId = bvm.AuthorId, 
                EmployeeId = userId,
                Isbn = bvm.Isbn,
                PublishYear = bvm.PublishYear,
                PublisherId = bvm.PublisherId
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string searchQuery)
        {
            var books = _context.Books
                .Include(b=> b.Author)
                .Include(b=> b.Publisher)
                .Where(b=> b.Title.Contains(searchQuery) ||
                            b.Author.Name.Contains(searchQuery));
            return View("Index", books);
        }
    }
}