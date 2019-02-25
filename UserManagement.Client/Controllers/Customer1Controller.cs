using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;
using UserManagement.Service;

namespace UserManagement.Client.Controllers
{
    public class Customer1Controller : Controller
    {
        CustomerService service = new CustomerService();
        // GET: Customer1
        public ActionResult Index()
        {
            var viewCustomer = service.GetCustomer();

            return View(viewCustomer);
        }

        public ActionResult Details(int id)
        {           
            var customer = service.GetCustomer(id);

            return View(customer);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //save customer data
            bool saved = service.Save(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            bool check = service.CheckValidity(username,password);

            if (check) return View("LoggedIn");

            else return View("Login");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer customer = service.GetDbCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            //save customer data
            bool saved = service.Update(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Customer customer = service.GetDbCustomer(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            //save customer data
            bool saved = service.Delete(customer);
            return RedirectToAction("Index");
        }
    }
}