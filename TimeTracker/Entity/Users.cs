using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int UserRole { get; set; }
    }
}