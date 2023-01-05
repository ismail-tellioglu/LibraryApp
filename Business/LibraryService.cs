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

        public List<BooksDto> SearchBooks(BookSearchDto criterias)
        {
           /* List<Books> matchedBooks;
            if(!string.IsNullOrEmpty(criterias.BookName) && !string.IsNullOrEmpty(criterias.ISDN) &&!string.IsNullOrEmpty(criterias.Author))*/
            var matchedBooks= unitOfWork.BookRepository.Get(p =>  (criterias.ISDN !=null && p.ISDN.ToUpper().Contains(criterias.ISDN.ToUpper()))
            || (criterias.Author!=null && p.AuthorName.ToUpper().Contains(criterias.Author.ToUpper())) 
            || (criterias.BookName!=null && p.Title.ToUpper().Contains(criterias.BookName.ToUpper()))).Result.ToList();

            return mapper.Map<List<Books>, List<BooksDto>>(matchedBooks);
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
            unitOfWork.Save();

            book.IsBooked = true;
            book._BookTransactions.Add(transaction);
            member._BookTransactions.Add(transaction);
            unitOfWork.Save();

            return "Success";
        }

        public async Task<DailyReportDto> DailyReport()
        {
            DailyReportDto dailyReports = new DailyReportDto();
            DateTime compareDate = businessHelper.CalculateDateAccordingToWorkDays(DateTime.Now, 3);
            var transactions =await unitOfWork.BookTransactionsRepository
                .Get(p=>p.EndDate.Date<compareDate.Date,null,"Book,Member");
            foreach (var item in transactions)
            {
                int dayDifference = businessHelper.CalculateDayDifferenceAccordingToWorkDays(item.EndDate,DateTime.Now);
                DailyReportItem dItem = new DailyReportItem();
                dItem.ISDN = item.TransactionId.ToString();
                dItem.MemberName = item.Member.Name;
                dItem.MemberId = item.Member.MemberId;
                dItem.BookName = item.Book.Title;
                dItem.ISDN = item.Book.ISDN;
                dItem.CheckOutDate = item.IssueDate;
                dItem.IsReturned = item.IsReturned;
                dItem.LastReturnDate = item.EndDate;
                dItem.PenaltyAmount = (!item.IsReturned && dayDifference < 0) ? businessHelper.CalculatePenalty(-dayDifference) : 0;
                dItem.RemainingDay = dayDifference > 0 ? dayDifference.ToString() : $"Past Due {-dayDifference} days";

                dailyReports.DailyReports.Add(dItem);
            }
            return dailyReports;
        }

    }
}