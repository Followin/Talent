using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.DAL.Models
{
    public class UserSkill
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid SkillId { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
