using FinalProject.Context;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CategoryController : Controller
    {
        CompanyContext dbContext = new CompanyContext();

        public IActionResult Index()
        {
            var categories = dbContext.Categories.ToList();
            return View(categories);
        }

        // Display details
        public IActionResult Details(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Create (GET)
        public IActionResult Create()
        {
            return View();
        }
        // Create (POST)
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Add(category);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //. Edit (GET)
        public IActionResult Edit(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // Edit (POST)
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // Delete (GET)
        public IActionResult Delete(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // Delete (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

