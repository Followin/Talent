using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.DAL.Models
{
    public class UserInterest
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid InterestId { get; set; }

        public virtual Interest Interest { get; set; }
    }
}
