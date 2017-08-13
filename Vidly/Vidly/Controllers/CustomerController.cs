using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var customer = _context.Custommers.Include(c=>c.MembershipType);
            return View(customer);
        }
        public ActionResult New()
        {
            var membershipType = _context.MembershipTypes.ToList();
            var customer = new NewCustomerViewModel
            {
                MembershipTypes = membershipType
            };
            return View(customer);
        }
        [HttpPost]
        public ActionResult Creat(Customer customer)
        {
            _context.Custommers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Details(int id)
        {
            var member = _context.Custommers.Include(c => c.MembershipType).SingleOrDefault(s => s.Id == id);
            if (member == null)
            {
                return HttpNotFound();
            }
            else 
            return View(member);
        }
        public ActionResult Edit(int id)
        {
            Customer customer = _context.Custommers.Find(id);
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            var custom = _context.Custommers.Single(c => c.Id == customer.Id);
            custom.MembershipTypeId = customer.MembershipTypeId;
            custom.Name = customer.Name;
            custom.BirthDate = customer.BirthDate;
            custom.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
    }
}