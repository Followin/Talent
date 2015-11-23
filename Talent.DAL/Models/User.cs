using System;
using System.Collections;
using System.Collections.Generic;

namespace Talent.DAL.Models
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
    }
}