using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.DAL.Models
{
    public class UserUser
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid FriendId { get; set; }

        public virtual User Friend { get; set; }
    }
}
