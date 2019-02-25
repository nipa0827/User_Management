using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("AIDummyDBEntities"){

        }

        public DbSet<Customer> Customers{ get; set; }
        
    }
}