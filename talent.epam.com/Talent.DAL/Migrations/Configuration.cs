using System;
using System.Threading.Tasks;
using Talent.DAL.Models;

namespace Talent.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EfContext>
    {
        public Configuration()
        {
        }

        protected override void Seed(EfContext context)
        {
            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleEn = "Football",
                TitleRu = "Футбол",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*footb.*|.*футб(?!олки).*|.*fc.*|.*фк.*", 
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleEn = "Basketball",
                TitleRu = "Баскетбол",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*(баскетб|basketb).*", 
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Классическая музыка",
                TitleEn = "Classical music",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*classic.*music.*|.*класси.*музык.*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleEn = "Poetry",
                TitleRu = "Поэзия",
                Category = "Poetry",
                Synonyms = new Synonym[]
                {
                    @".*поэ.*|.*стих.*|poe.*|verses"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleEn = "Popular music",
                TitleRu = "Популярная музыка",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*поп.*музык.*|.*pop.*(music)?"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Бокс",
                TitleEn = "Boxing",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*(boxin|бокс).*"
                }
            });

            context.Accounts.Add(new Account
            {
                Id = Guid.NewGuid(),
                Login = "Admin",
                Password = "Admin"
            });

            var task = context.SaveChangesAsync();
            task.Wait();
        }
    }
}