using LearnAspMVC.Data;
using LearnAspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnAspMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        /*List all categories*/
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _db.Categories;

            return View(categoryList);
        }

        /* Create a new category (GET) */
        public IActionResult New()
        {
            return View();
        }

        /* Create a new category (POST) */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category values)
        {
            _db.Add(values);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        /*Show category details*/
        public IActionResult Show()
        {
            return View();
        }
    }
}
