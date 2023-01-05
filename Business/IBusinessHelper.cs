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
    }
}
