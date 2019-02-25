using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.ViewModels
{
    public class ViewLogin
    {
        public int Id { get; set; }
        public int CustomerId{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
