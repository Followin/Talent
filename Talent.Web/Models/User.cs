using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent.Web.Models
{
    public class User
    {
        public String Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string[] Interests { get; set; }

        public string[] Groups { get; set; }
    }
}