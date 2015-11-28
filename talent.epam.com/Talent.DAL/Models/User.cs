using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.DAL.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string VkId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoLink { get; set; }

        public string Project { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual ICollection<UserInterest> Interests { get; set; }

        public virtual ICollection<UserSkill> Skills { get; set; }

        public virtual ICollection<UserUser> Friends { get; set; }
    }
}