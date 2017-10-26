using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Website
{
    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        // An application user, in this website, can be either an Employee or a Customer
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
    }
}

//namespace NorthwindTraders.Security.Entities
//{
//    class ApplicationUser
//    {
//    }
//}
