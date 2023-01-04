using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Entities
{
    public class Members
    {
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }

        public ICollection<BookTransactions> BookTransactions;
        public ICollection<BookTransactions> _BookTransactions
        {
            get { return BookTransactions ?? (BookTransactions = new Collection<BookTransactions>()); }
            protected set { BookTransactions = value; }
        }

    }
}
