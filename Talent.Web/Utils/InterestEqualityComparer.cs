using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Talent.DAL.Models;

namespace Talent.Web.Utils
{
    public class InterestEqualityComparer : IEqualityComparer<Interest>
    {
        public bool Equals(Interest x, Interest y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Interest obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}