using AutoMapper;
using Bogus.DataSets;
using Db.Interfaces;
using Objects.Dtos;
using Objects.Entities;

namespace Business
{
    public class LibraryService:ILibraryService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private readonly IBusinessHelper businessHelper;
        public LibraryService(IUnitOfWork unitOfWork, IMapper mapper, IBusinessHelper helper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.businessHelper = helper;
        }

        public async Task<List<BooksDto>> SearchBooks(BookSearchDto criterias)
        {
            var matchedBooks= await unitOfWork.BookRepository.Get(p =>  (criterias.ISDN !=null && p.ISDN.ToUpper().Contains(criterias.ISDN.ToUpper()))
            || (criterias.Author!=null && p.AuthorName.ToUpper().Contains(criterias.Author.ToUpper())) 
            || (criterias.BookName!=null && p.Title.ToUpper().Contains(criterias.BookName.ToUpper())));

            return mapper.Map<List<Books>, List<BooksDto>>(matchedBooks.ToList());
        }
        public async Task<string> CheckOut(CheckOutDto checkOut)
        {
            var book = await unitOfWork.BookRepository.GetByID(checkOut.ISDNToCeheckOut);
            var member = await unitOfWork.MemberRepository.GetByID(checkOut.MemberId);
            if (book == null)
                return "Book can not be found";
            if (book.IsBooked)
                return "Book is not available for check out.";
            if (member == null)
                return "Member not found";
            BookTransactions transaction = new BookTransactions
            {
                TransactionId = new Guid(),
                EndDate = checkOut.EndDate,
                IsReturned = false,
                IssueDate = DateTime.Now,
                BookISDN= book.ISDN,
                MemberId=member.MemberId
            };
            unitOfWork.BookTransactionsRepository.Insert(transaction);
            book.IsBooked = true;
            unitOfWork.Save();

            return "Success";
        }

        public async Task<DailyReportDto> DailyReport()
        {
            DailyReportDto dailyReports = new DailyReportDto();
            DateTime compareDate = businessHelper.CalculateDateAccordingToWorkDays(DateTime.Now, 2);
            var transactions =await unitOfWork.BookTransactionsRepository
                .Get(p=>p.EndDate.Date<=compareDate.Date,null, "Book,Member");//orderBy: q => q.OrderByDescending(d => d.Book.Title)
            foreach (var item in transactions)
            {
                DailyReportItem dItem = new DailyReportItem();
                dItem.RemainingNum = businessHelper.CalculateDayDifferenceAccordingToWorkDays(item.EndDate, DateTime.Now);
                dItem.ISDN = item.TransactionId.ToString();
                dItem.MemberName = item.Member.Name;
                dItem.MemberId = item.Member.MemberId;
                dItem.BookName = item.Book.Title;
                dItem.ISDN = item.Book.ISDN;
                dItem.CheckOutDate = item.IssueDate;
                dItem.IsReturned = item.IsReturned;
                dItem.LastReturnDate = item.EndDate;
                dItem.PenaltyAmount = (!item.IsReturned && dItem.RemainingNum < 0) ? businessHelper.CalculatePenalty(-dItem.RemainingNum) : 0;
                dItem.RemainingDay = dItem.RemainingNum > 0 ? dItem.RemainingNum.ToString() : $"Past Due {-dItem.RemainingNum} days";

                dailyReports.DailyReports.Add(dItem);
            }
            dailyReports.DailyReports = dailyReports.DailyReports.OrderBy(p => p.RemainingNum).ToList();
            return dailyReports;
        }

    }
}