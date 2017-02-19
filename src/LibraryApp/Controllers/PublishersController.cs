using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibraryApp.Controllers
{
    public class PublishersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublishersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Publishers";
            var publishers = _context.Publishers.ToList();
            return View(publishers);
        }

        public IActionResult Create()
        {
            ViewData["Message"] = "Create Publisher";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}