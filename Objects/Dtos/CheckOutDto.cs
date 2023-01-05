using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Dtos
{
    public class CheckOutDto
    {
        public string ISDNToCeheckOut { get; set; }
        [Required(ErrorMessage = "Required")]
        public int MemberId { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime StartDate { get; set; }
    }
}
