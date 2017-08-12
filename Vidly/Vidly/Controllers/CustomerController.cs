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
            var MembershipType = _context.MembershipTypes.ToList();
            var customer = new NewCustomerViewModel
            {
                MembershipTypes = MembershipType
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
        public ActionResult Details(int Id)
        {
            var member = _context.Custommers.Include(c => c.MembershipType).SingleOrDefault(s => s.Id == Id);
            if (member == null)
            {
                return HttpNotFound();
            }
            else 
            return View(member);
        }
    }
}