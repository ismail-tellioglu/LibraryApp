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
    }
}
