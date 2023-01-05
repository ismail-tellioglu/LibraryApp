using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Entities
{
    public class Holidays
    {
        [Key]
        public DateTime Date { get; set; }
    }
}
