using System.Data.Entity;
using Talent.DAL.Models;

namespace Talent.DAL
{
    public class EfInitializer : DropCreateDatabaseIfModelChanges<EfContext>
    {
        public override void InitializeDatabase(EfContext context)
        {
            context.Interests.Add(new Interest
            {
                TitleEn = "Football",
                TitleRu = "Футбол",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*footb.*|.*футб.*|.*fc.*|.*фк.*", 
                }
            });

            context.Interests.Add(new Interest
            {
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
                TitleRu = "Классичесская музыка",
                TitleEn = "Classical music",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*classic.*music.*|.*классич.*музыка.*"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleEn = "Poetry",
                TitleRu = "Поэзия",
                Category = "Poetry",
                Synonyms = new Synonym[]
                {
                    @".*стих.*|.*поэз.*|poe.*|verses"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleEn = "Popular music",
                TitleRu = "Популярная музыка",
                Category = "Music",
                Synonyms = new Synonym[]
                {
                    @".*поп.*музыка.*|.*pop.*(music)?"
                }
            });

            context.Interests.Add(new Interest
            {
                TitleRu = "Бокс",
                TitleEn = "Boxing",
                Category = "Sport",
                Synonyms = new Synonym[]
                {
                    @".*(boxin|бокс).*"
                }
            });

            context.SaveChangesAsync();
        }
    }
}
