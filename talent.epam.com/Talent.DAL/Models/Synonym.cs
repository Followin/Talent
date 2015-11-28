using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.DAL.Models
{
    public class Synonym
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Text { get; set; }

        public virtual Interest Interest { get; set; }

        public static implicit operator Synonym(string s)
        {
            return new Synonym() {Text = s};
        }
    }
}
