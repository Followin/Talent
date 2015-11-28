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

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<UserInterest> UserInterests { get; set; }

        public DbSet<UserUser> UserUsers { get; set; }

        public EfContext()
        {
            Database.SetInitializer(new EfInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSkill>().HasKey(x => new {x.UserId, x.SkillId});
            modelBuilder.Entity<UserInterest>().HasKey(x => new {x.UserId, x.InterestId});
            modelBuilder.Entity<UserUser>().HasKey(x => new {x.UserId, x.FriendId});
            modelBuilder.Entity<User>().HasMany(x => x.Friends).WithRequired(x => x.Friend).WillCascadeOnDelete(false);
        }
    }
}
