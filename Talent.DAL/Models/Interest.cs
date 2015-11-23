using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.DAL.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public string TitleRu { get; set; }

        public string TitleEn { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Synonym> Synonyms { get; set; }

        public virtual ICollection<User> Users { get; set; } 
    }
}
