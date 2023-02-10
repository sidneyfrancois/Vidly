using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Context;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private VidlyDataContext _context;

        public CustomerController()
        {
            _context = new VidlyDataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var viewModel = new ListOfCustomersViewModel
            {
                Customers = _context.Customers.Include((c) => c.MemberShipType).ToList()
            };

            return View(viewModel);
        }

        [Route("Customer/Details/{id:int}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include((c) => c.MemberShipType).ToList().Find(item => item.Id == id);

            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}