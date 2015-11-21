using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Talent.Web.Models;

namespace Talent.Web.Static
{
    public static class UsersList
    {
        public static List<User> Users { get; private set; }


        static UsersList()
        {
            Users = new List<User>();
        }
    }
}