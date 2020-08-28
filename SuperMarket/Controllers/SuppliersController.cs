using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperMarket.Models;
using Newtonsoft.Json;

namespace SuperMarket.Controllers
{
    public class SuppliersController : Controller
    {
        private ApplicationDbContext _context;
        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult test()
        {
            return View();
        }
        public ActionResult getSuppliers()
        {
           var suppliers = _context.Suppliers.ToList();
            return Json(new {data=suppliers }, JsonRequestBehavior.AllowGet);
        } 
        // GET: Suppliers
        public ActionResult Index()
        {
           
            return View("Index");
        }
       
        public ActionResult New()
        {
            
            return View("SupplierForm");
        }
        public void Save(Supplier supplier, bool afterSave=false)
        {
            if(supplier.Id == 0)
            {
                _context.Suppliers.Add(supplier);

            }
            _context.SaveChanges();
           
              

            
        }
    }
}