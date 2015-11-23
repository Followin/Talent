using System.Threading.Tasks;
using Talent.DAL.Models;

namespace Talent.DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EfContext context)
        {
            context.Interests.Add(new Interest
            {
                TitleEn = "Football",
                TitleRu = "������",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*footb.*|.*����.*|.*fc.*|.*��.*", 
                }
            });

            context.Interests.Add(new Interest
            {
                TitleEn = "Basketball",
                TitleRu = "���������",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*(�������|basketb).*", 
                }
            });

            context.Interests.Add(new Interest
            {
                TitleRu = "������������� ������",
                TitleEn = "Classical music",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*classic.*music.*|.*�������.*������.*"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleEn = "Poetry",
                TitleRu = "������",
                Category = "Poetry",
                Synonyms = new Synonym[]
                {
                    @".*����.*|.*����.*|poe.*|verses"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleEn = "Popular music",
                TitleRu = "���������� ������",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*���.*������.*|.*pop.*(music)?"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleRu = "����",
                TitleEn = "Boxing",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*(boxin|����).*"
                }
            });

            var task = context.SaveChangesAsync();
            task.Wait();
        }
    }
}
