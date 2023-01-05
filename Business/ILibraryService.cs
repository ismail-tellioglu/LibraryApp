using Objects.Dtos;
using Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ILibraryService
    {
        List<BooksDto> SearchBooks(BookSearchDto criterias);
        Task<string> CheckOut(CheckOutDto checkOut);
        Task<DailyReportDto> DailyReport();
    }
}
