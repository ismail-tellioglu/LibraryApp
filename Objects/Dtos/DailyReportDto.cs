using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Dtos
{
    public class DailyReportDto
    {
        public List<DailyReportItem> DailyReports { get; set; }
        public DailyReportDto()
        {
            DailyReports = new List<DailyReportItem>();
        }
    }

    public class DailyReportItem
    {
        public string ISDN { get; set; }
        public string BookName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime LastReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public decimal PenaltyAmount { get; set; }
        public string RemainingDay { get; set; }
    }
}
