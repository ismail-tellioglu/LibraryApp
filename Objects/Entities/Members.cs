using System;
using System.Collections.Generic;
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
        public ICollection<BookTransactions> BookTransactions { get; set; }

    }
}
