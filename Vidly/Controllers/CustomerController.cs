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

        // GET: Customer
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

    }
}