using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        
        public List<Customer> customers = new List<Customer>
        {
            //new Customer { Id = 1, Name = "John Smith" },
            //new Customer { Id = 2, Name = "Mary Williams" }
        };

        // GET: Customer
        public ActionResult Index()
        {
            var viewModel = new ListOfCustomersViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Customer/Details/{id:int}")]
        public ActionResult Details(int id)
        {
            var customer = customers.Find(item => item.Id == id);

            if (customer != null)
                return View(customer);
            else
                return HttpNotFound();
        }
    }
}