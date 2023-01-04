using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Entities
{
    public  class Books
    {
      
        [Key]
        public string ISDN { get; set; }

        public string AuthorName { get; set; }  
        public string Title { get; set; }   
        public bool IsBooked { get; set; }

        public ICollection<BookTransactions> BookTransactions;

        public ICollection<BookTransactions> _BookTransactions
        {
            get { return BookTransactions ?? (BookTransactions = new Collection<BookTransactions>()); }
            set { BookTransactions = value; }
        }
    }
}
