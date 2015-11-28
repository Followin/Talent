﻿using System;
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

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Искусство",
                TitleEn = "Art",
                Category = "Art",
                Synonyms = new Synonym[]
                {
                    @".*(искусс(?!.+быть)(?<!(как|новое|боев).+)|art|арт|творч|талант|абстрак).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Живопись",
                TitleEn = "Painting",
                Category = "Art",
                Synonyms = new Synonym[]
                {
                    @".*(живопис|paintin|картин|рис(ун|ов)).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Наука",
                TitleEn = "Science",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(нау(к|ч)|science|tech|изобр|intell|технол|инновац).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Философия",
                TitleEn = "Philosophy",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(philoso|фолософ(?<!(это|как|наша).*)).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Религия",
                TitleEn = "Religion",
                Category = "Religion",
                Synonyms = new Synonym[]
                {
                    @".*(христиан|ислам|будд|православ|духовн|языч|религи(?<!(это.*|как.*|наша.*))(?!.*атеи)(?<!.*атеи).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Юмор",
                TitleEn = "Humor",
                Category = "Entertainment",
                Synonyms = new Synonym[]
                {
                    @".*(сме[хш]|анекдот|прикол|jok[ei]|fun).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Астрология",
                TitleEn = "Astrology",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(гороскоп|овен|телец|близнецы|рак|лев|дева|весы|скорпион|стрелец|козерог|водолей|рыбы).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Космос",
                TitleEn = "Space",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(space|космо).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Мода",
                TitleEn = "Fashion",
                Category = "Entertainment",
                Synonyms = new Synonym[]
                {
                    @".*(мод[на]|плать[яе]|обув|туфл|бренд).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Иностранные языки",
                TitleEn = "Foreign languages",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(italiano|english|espanol|deutsch|(английский|итальянсий|испанский|немецкий)(?=.*язык)).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "История",
                TitleEn = "History",
                Category = "Science",
                Synonyms = new Synonym[]
                {
                    @".*(histor|истори[^и]).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Путешествия",
                TitleEn = "Travelling",
                Category = "Entertainment",
                Synonyms = new Synonym[]
                {
                    @".*(путешеств|tour|тури[сз](?<!куль)|travel).*"
                }
            });

            context.Interests.Add(new Interest
            {
                Id = Guid.NewGuid(),
                TitleRu = "Киноискусство",
                TitleEn = "Movies",
                Category = "Entertainment",
                Synonyms = new Synonym[]
                {
                    @".*(кино(?!лог)|фильм|movie).*"
                }
            });



            context.Accounts.Add(new Account
            {
                Id = Guid.NewGuid(),
                Login = "Admin",
                Password = "Admin"
            });

            context.Accounts.Add(new Account
            {
                Id = Guid.NewGuid(),
                Login = "NotAdmin",
                Password = "Admin"
            });

            var task = context.SaveChangesAsync();
            task.Wait();
        }
    }
}