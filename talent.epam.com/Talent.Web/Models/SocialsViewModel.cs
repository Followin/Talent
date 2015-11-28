using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent.Web.Models
{
    public class SocialsViewModel
    {
        public AuthModel Vk { get; set; }

        public LinkedInAuthModel LinkedIn { get; set; }
    }
}