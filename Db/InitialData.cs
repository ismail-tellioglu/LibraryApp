using Bogus;
using Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public static class InitialData
    {
        public static List<Books> books = new List<Books>();
        public static List<Members> members = new List<Members>();

        public static void Init(int count)
        {
            var Isdns = new List<string> { "111111111", "222222222", "333333333" };
            var Titles = new List<string> { "Da Vinci Code", "Game of Thrones", "1984" };
            var Authors = new List<string> { "Dan Brown", "G.R.R Martin", "george orwell" };
            int IndexForIsdns = 0;
            int IndexForTitle = 0;
            int IndexForAuthors = 0;
            var bookfaker = new Faker<Books>()
               .RuleFor(p => p.ISDN, f => Isdns[IndexForIsdns++])
               .RuleFor(p => p.Title, f => Titles[IndexForTitle++])
               .RuleFor(p => p.AuthorName, f => Authors[IndexForAuthors++])
               .RuleFor(p=>p.IsBooked,_=>false);

            books = bookfaker.Generate(count);

            var memberFaker = new Faker<Members>()
               .RuleFor(b => b.Name, f => f.Name.FullName())
               .RuleFor(b => b.MemberId, f => f.Random.Int());

            members = memberFaker.Generate(count);
        }
    }
}
