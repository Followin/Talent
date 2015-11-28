using System.Data.Entity;
using Talent.DAL.Models;

namespace Talent.DAL
{
    public class EfContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Synonym> Synonyms { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Account> Accounts { get; set; }


        public EfContext()
        {
            Database.SetInitializer(new EfInitializer());
        }
    }
}
