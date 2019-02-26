using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Models;
using UserManagement.Service;
using UserManagement.ViewModels;

namespace UserManagement.Client.Controllers
{
    public class Customer1Controller : Controller
    {
        CustomerService service = new CustomerService();
       
        [HttpGet]
        public ActionResult Login()
        {

            return View("Login");
        }

        [HttpGet]
        public bool CheckLogin(string username, string password)
        {
            bool check = service.CheckValidity(username,password);

            return check;
        }


        [HttpGet]
        public ActionResult ViewRegister()
        {
            return View("Register");
        }

        [HttpGet]
        public bool Register(string firstName, string lastName, string email, string role, string username, string password)
        {
            Role myRole;
            Enum.TryParse(role, out myRole);
            Customer customer = new Customer();

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.CustomerRole = myRole;
            customer.Username = username;
            customer.Password = password;

            service.Save(customer);
            return true;
        }
    }
}