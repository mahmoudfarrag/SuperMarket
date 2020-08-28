using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.Models;
using SuperMarket.ViewModels;
using SuperMarket.Dtos;

namespace SuperMarket.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _context;
        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult New2(int catId)
        {
            ViewBag.CategoryId = catId;
            return View("popUpForm");
        }

        //for ajax call
        public ActionResult getProducts(int id)
        {
            var products = _context.Products.Where(p => p.CategoryId == id).ToList();
            return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }
        // GET: Product
        
            
        public ActionResult getProds(int id) {
            var products = _context.Products.Where(p => p.CategoryId == id).ToList();
            var viewModel = new ProductViewModel {
                Products = products,
                Category = _context.Categories.Single(c=>c.Id == id)

            };
            return View("Index", viewModel);

        }
        public ActionResult New(int categoryId)
        {
            var category = _context.Categories.Single(c => c.Id == categoryId);
            var viewModel = new ProductFormViewModel {
                Category = category
            };
            return View("ProductForm",viewModel);
        }

        // save will applay when data come from popUpform
        public ActionResult Save2(FormCollection form)
        {
            var categoryid = Convert.ToInt32(form["CategoeyId"]);
            var category = _context.Categories.Single(c => c.Id == categoryid);
            var product = new Product
            {
                Category=category,
                CategoryId =categoryid,
                Name = form["Name"],
                NumberInStock = Convert.ToInt32(form ["NumberInStock"]),
                Price = Convert.ToInt32(form["Price"]),
                isDeleted = false

            };

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("New", "SupplyOperations", new { id = product.CategoryId });
        }
        public ActionResult Save(Product product) {
            if(product.Id ==0)
            {
                product.isDeleted = false;
               _context.Products.Add(product);
            }
           
            _context.SaveChanges();
            return RedirectToAction("getProds", "Products",new { id=product.CategoryId});
        }
    }
}