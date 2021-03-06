﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent.Web.Models
{
    public class Node
    {
        public string id { get; set; }

        public int value { get; set; }

        public string image { get; set; }

        public string title { get; set; }

        public string group { get; set; }

        public string project { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public string skype { get; set; }

        public bool isFriend { get; set; }
    }
}