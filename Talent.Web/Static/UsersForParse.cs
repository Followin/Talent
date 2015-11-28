using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Talent.Web.Models;

namespace Talent.Web.Static
{
    public class UsersForParse
    {
        public static List<UserForParse> Users { get; set; }

        static UsersForParse()
        {
            Users = new List<UserForParse>();
            Users.Add(new UserForParse
            {
                Name = "Andrii Gordiichuk",
                VkId = "4603804",
                Email = "Andrii_Gordiichuk@epam.com",
                Phone = "+380976803379"
            });

        }
    }
}