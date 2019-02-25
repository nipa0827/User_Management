using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.ViewModels;

namespace UserManagement.Service
{
    public class CustomerService
    {
        CustomerContext db = new CustomerContext();

        public List<ViewCustomer> GetCustomer(){
            //create a db object
            

            List<Customer> customers = db.Customers.ToList();
            List<ViewCustomer> viewCustomers = new List<ViewCustomer>();

            foreach(Customer customer in customers){
                ViewCustomer viewCustomer = new ViewCustomer()
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    CustomerRole = customer.CustomerRole.ToString(),
                    Username = customer.Username,
                    Password = customer.Password
                };

                viewCustomers.Add(viewCustomer);
            }

            return viewCustomers;
        }

        public Customer GetDbCustomer(int id)
        {
            return db.Customers.Find(id);
        }

        public bool CheckLogin()
        {
            


            //ViewCustomer viewCustomer = new ViewCustomer()
            //{
            //    FirstName = customer.FirstName,
            //    LastName = customer.LastName,
            //    Email = customer.Email,
            //    Role = customer.Role.ToString(),
            //    Username = customer.Username,
            //    Password = customer.Password
            //};

            //ViewLogin viewLogin = new ViewLogin()
            //{
            //    Username = login.Username,
            //    Password = login.Password
            //};

            //if (customer == null) return false;
            //if(viewCustomer.Username.Equals(viewLogin.Username) && viewCustomer.Username.Equals(viewLogin.Password)){
            //    db.Logins.Add(login);
            //    db.SaveChanges();
            //    return true;
            //}
           
            return true;    
        }

        public bool CheckValidity(string username, string password)
        {
            bool flag = false;
            List<Customer> customers = db.Customers.ToList();

            foreach (Customer customer in customers)
            {
                if(customer.Username.Equals(username) && customer.Password.Equals(password)){
                    flag = true;
                    break;
                }
            }

            return flag;
           
        }

        public ViewCustomer GetCustomer(int id)
        {
            Customer customer = db.Customers.Find(id);

            return new ViewCustomer() { 
            FirstName=customer.FirstName,
            LastName=customer.LastName,
            Email=customer.Email,
            CustomerRole=customer.CustomerRole.ToString(),
            Username=customer.Username,
            Password=customer.Password};

        }

        public bool Update(Customer customer)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }

        public bool Delete(Customer customer)
        {
            Customer dbCustomer = db.Customers.Find(customer.Id);
            db.Customers.Remove(dbCustomer);
            db.SaveChanges();

            return true;
        }

        public bool Save(Customer customer){
            db.Customers.Add(customer);
            db.SaveChanges();

            return true;
        }

        
    }
}
