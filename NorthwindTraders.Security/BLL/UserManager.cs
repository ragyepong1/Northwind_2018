using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NorthwindTraders.DAL;
using NorthwindTraders.Security.BLL;
using NorthwindTraders.Security.Entities; // UserProfile
using System;
using System.Collections.Generic; // List<T>
using System.ComponentModel; // [DataObject] et.al.
using System.Configuration;
using System.Linq; // for various Entension methods
using System.Text;
using System.Threading.Tasks;

namespace Website
{
    [DataObject]
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }

        public void AddWebMaster()
        {
            // Add a web master user, if one doesn't exist
            string username = ConfigurationManager.AppSettings["adminUserName"];
            if(!Users.Any(u => u.UserName.Equals(username)))
            {
                var webMasterAccount = new ApplicationUser()
                {
                    UserName = username,
                    Email = ConfigurationManager.AppSettings["adminEmail"], // nice happenstance
                    EmailConfirmed = true
                };
                this.Create(webMasterAccount, ConfigurationManager.AppSettings["adminPassword"]);
                // Add the webmaster account to the Administrators security role
                this.AddToRole(webMasterAccount.Id, ConfigurationManager.AppSettings["adminRole"]);
            }
        }

        #region Standard CRUD Operations for Users
            [DataObjectMethod(DataObjectMethodType.Select)]
            public List<UserProfile> ListAllUsers()
            {
            var rm = new RoleManager();
            // The UserManager for ASP.NET Identity has a built-in property for all users
            var result = from person in Users.ToList()
                         select new UserProfile
                         {
                             UserId = person.Id,
                             UserName = person.UserName,
                             EmailService = person.Email,
                             EmailConfirmed = person.EmailConfirmed,
                             CustomerId = person.CustomerId,
                             EmployeeId = person.EmployeeId,
                             RoleMemberships = person.Roles.Select(r => rm.FindById(r.RoleId).Name )
                         };
            using (var context = new NorthwindContext())
            {
                foreach (var person in result)
                    if (person.EmployeeId.HasValue)
                        person.FullName = context.Employees.Find(person.EmployeeId).FirstName + " " + context.Employees.Find(person.EmployeeId).LastName;
                    else if (!string.IsNullOrEmpty(person.CustomerId))
                        person.FullName = context.Customers.Find(person.CustomerId).ContactName;
            }   
            return result.ToList();
            }
        #endregion
    }
}

//namespace NorthwindTraders.Security.BLL
//{
//    class UserManager
//    {
//    }
//}
