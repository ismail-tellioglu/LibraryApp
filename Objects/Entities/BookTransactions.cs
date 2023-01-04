using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Entities
{
    public class BookTransactions
    {
        [Key]
        public Guid TransactionId { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Boolean IsReturned { get; set; }

        public DateTime? ReturnDate { get; set; }

        public decimal PenaltyAmount { get; set; }

    }
}
