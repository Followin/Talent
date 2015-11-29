using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Talent.DAL.Models;

namespace Talent.Web.Utils
{
    public class SkillEqualityComparer : IEqualityComparer<Skill>
    {
        public bool Equals(Skill x, Skill y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Skill obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}