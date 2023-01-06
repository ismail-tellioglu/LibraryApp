using AutoMapper;
using Db.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessHelper : IBusinessHelper
    {
        private IUnitOfWork unitOfWork;
        public BusinessHelper(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public DateTime CalculateDateAccordingToWorkDays(DateTime startDate, int duration)
        {
            int count = 0;
            var holidays = unitOfWork.HolidaysRepository.GetAllAsync().Result;
            DateTime endDate = startDate;
            while (count < duration)
            {
               endDate = endDate.AddDays(1);
                if( !holidays.Where(p=>p.Date==endDate.Date).Any() && endDate.DayOfWeek!=DayOfWeek.Saturday && endDate.DayOfWeek!=DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return endDate;
        }
        public int CalculateDayDifferenceAccordingToWorkDays(DateTime date1, DateTime date2)
        {
            int count = 0;
            int coefficient = 1;
            var holidays = unitOfWork.HolidaysRepository.GetAllAsync().Result;
            if (date1.Date < date2.Date)
                coefficient = -1;
            while (date1.Date != date2.Date)
            {
                try
                {
                    date1 = date1.AddDays(1 * -coefficient);
                    if (!holidays.Where(p => p.Date == date1.Date).Any() && date1.DayOfWeek != DayOfWeek.Saturday && date1.DayOfWeek != DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return count*coefficient;
        }
        public Decimal CalculatePenalty(int dayCount)
        {
            decimal coefficient = 0.2M;
            //according to request document at first day Fibonacci (0) is used. That is why daycount-1 used for fiboncacci calculation
            if (dayCount > 1)
                return GetFibonacciSum(dayCount - 1) * coefficient + CalculatePenalty(dayCount - 1);
            else if (dayCount == 1)
                return GetFibonacciSum(dayCount - 1) * coefficient;
            else
                return 0;
        }

        private  int GetFibonacciSum(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return GetFibonacciSum(n - 1) + GetFibonacciSum(n - 2);
        }
    }
}
