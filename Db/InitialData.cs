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
        public static List<Holidays> holidays = new List<Holidays>();

        public static void Init(int count)
        {
            var Isdns = new List<string> { "0000","1111", "2222", "3333", "4444", "5555","6666","7777","8888","99999" };
            var Titles = new List<string> { "Da Vinci Code", "Game of Thrones", "1984", "The House of Mirth", "The Sun Also Rises",
            "Number the Stars","Brave New World","Pale Fire","Cold Comfort Farm","Gone With the Wind "};
            var Authors = new List<string> { "Dan Brown", "G.R.R Martin", "George Orwell", "Edith Wharton", "Ernest Hemingway",
            "Lois Lowry", "Aldous Huxley", "Vladimir Nabokov","Stella Gibbons","Margaret Mitchell"};
            int IndexForIsdns = 0;
            int IndexForTitle = 0;
            int IndexForAuthors = 0;
            var bookfaker = new Faker<Books>()
               .RuleFor(p => p.ISDN, f => Isdns[IndexForIsdns++])
               .RuleFor(p => p.Title, f => Titles[IndexForTitle++])
               .RuleFor(p => p.AuthorName, f => Authors[IndexForAuthors++])
               .RuleFor(p=>p.IsBooked,_=>false);
            books = bookfaker.Generate(Isdns.Count);

            var memberFaker = new Faker<Members>()
               .RuleFor(b => b.Name, f => f.Name.FullName())
               .RuleFor(b => b.MemberId, f => f.Random.Int(1));
            members = memberFaker.Generate(count);

            var holidaysList = new List<DateTime> {new DateTime(2023,1,1), new DateTime(2023,4,21),new DateTime(2023,4,22),
            new DateTime(2023,4,23),new DateTime(2023,5,1),new DateTime(2023,5,19),new DateTime(2023,6,28),
            new DateTime(2023,6,29),new DateTime(2023,6,30),new DateTime(2023,7,1),new DateTime(2023,7,15),
            new DateTime(2023,8,30),new DateTime(2023,10,29)};
            int IndexForHolidays = 0;
            var holidaysFaker = new Faker<Holidays>()
               .RuleFor(p => p.Date, f => holidaysList[IndexForHolidays++]);
            holidays = holidaysFaker.Generate(holidaysList.Count);

        }
    }
}
