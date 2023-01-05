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
                if (date1 < date2)
                    date1 = date1.AddDays(1);
                else
                    date1 = date1.AddDays(-1);
                if (!holidays.Where(p => p.Date == date1.Date).Any() && date1.DayOfWeek != DayOfWeek.Saturday && date1.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return count*coefficient;
        }
        public Decimal CalculatePenalty(int dayCount)
        {
            decimal coefficient = 0.2M;
            if (dayCount > 1)
                return GetFibonacciSum(dayCount) * coefficient + CalculatePenalty(dayCount - 1);
            else
                return GetFibonacciSum(dayCount) * coefficient;
        }

        private int GetFibonacciSum(int n)
        {
            int number = n - 1; 
            int[] fib = new int[number + 1];
            fib[0] = 0;
            if (n > 1)
                fib[1] = 1;
            for (int i = 2; i <= number; i++)
            {
                fib[i] = fib[i - 2] + fib[i - 1];
            }
            return fib[number];
        }

    }
}
