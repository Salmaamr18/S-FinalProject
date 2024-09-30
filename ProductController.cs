using FinalProject.Context;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ProductController : Controller
    {
        CompanyContext dbContext = new CompanyContext();

        // a. Display a table of all products with a link to details, add, edit, and delete
        public IActionResult Index()
        {
            var products = dbContext.Products.ToList();  
            return View(products);
        }

        // b. Display details of one product
        public IActionResult Details(int id)
        {
            var product = dbContext.Products.Include(P => P.Category).FirstOrDefault(P => P.ProductId == id);
            return View(product);
        }

        // c. Create new product (GET)
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Categories = new SelectList(dbContext.Categories , "CategoryId", "Name");
            return View();
        }

        // c. Create new product (POST)
        [HttpPost]
        public IActionResult Create(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // d. Edit an existing product (GET)
        public IActionResult Edit(int id)
        {
            var product = dbContext.Products.Include(P=>P.Category).FirstOrDefault(P=>P.ProductId==id);
            ViewBag._Categories = new SelectList(dbContext.Categories, "CategoryId", "Name");
            return View(product);
        }

        // d. Edit an existing product (POST)
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            dbContext.Products.Update(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // e. Delete a product (GET)
        public IActionResult Delete(int id)
        {
            var product = dbContext.Products.Find(id);
            return View(product);
        }
    }
}

