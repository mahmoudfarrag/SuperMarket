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
    public class SupplyOperationsController : Controller
    {
        private ApplicationDbContext _context;
        public SupplyOperationsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: SupplyOperations
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
           // var vm = new SupplyOperationFormViewModel();
            return View("SupplyOperationForm");
        }

        [HttpPost]
        public ActionResult Save(SupplyOperationDto supplyOperation)
        {
            var supplier = _context.Suppliers.Single(s => s.Id == supplyOperation.SupplierId);
            var product = _context.Products.Single(p => p.Id == supplyOperation.ProductId);
            var supplyOperationModel = new SupplyOperation {
                Supplier=supplier,
                Product= product,
                SupplayDate=supplyOperation.SupplayDate,
                Quantity=supplyOperation.Quantity
            };
            _context.SupplyOperations.Add(supplyOperationModel);
            _context.SaveChanges();
            return RedirectToAction("New");
        }
    }
}