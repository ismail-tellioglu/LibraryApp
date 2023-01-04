using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Dtos
{
    public class BookSearchDto
    {
        public string BookName { get; set; }
        public string Author { get; set; }

        public string ISDN { get; set; }
    }
}
