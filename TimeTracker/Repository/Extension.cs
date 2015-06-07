using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracker.Repository
{
    public static class Extension
    {
        public static string ConvertRow(string role)
        {
            var rolee = (role == "1") ? "Admin" : "User";
            return rolee;
        }
    }
}