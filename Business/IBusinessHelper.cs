using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBusinessHelper
    {
        DateTime CalculateDateAccordingToWorkDays(DateTime startDate, int duration);
        Decimal CalculatePenalty(int dayCount);
        int CalculateDayDifferenceAccordingToWorkDays(DateTime date1, DateTime date2);
    }
}
