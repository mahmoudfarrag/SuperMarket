using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.Models;

namespace SuperMarket.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
        public ActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Json(new { data = categories }, JsonRequestBehavior.AllowGet);

          
        }

        public ActionResult New()
        {

            return View("CategoryForm");
        }

        public ActionResult Save(Category category)
        {
            

            if(category.Id ==0)
                _context.Categories.Add(category);
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.Id == category.Id);
                categoryInDb.Name = category.Name;
                categoryInDb.isDeleted = false;
            }
             _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category == null)
                return HttpNotFound();

            return View("CategoryForm", category);
        }
    }
}