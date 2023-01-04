using AutoMapper;
using Db.Interfaces;
using Objects.Dtos;
using Objects.Entities;

namespace Business
{
    public class BookService:IBookService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public List<BooksDto> GetAllBooks()
        {
            return  mapper.Map<List<Books>,List<BooksDto>>(unitOfWork.BookRepository.GetAllAsync().Result);
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
                EndDate = DateTime.Now.AddDays(30),
                IsReturned = false,
                IssueDate = DateTime.Now,
                PenaltyAmount = 0
            
            };
            unitOfWork.BookTransactionsRepository.Insert(transaction);
            unitOfWork.Save();

            book.IsBooked = true;
            book._BookTransactions.Add(transaction);
            member._BookTransactions.Add(transaction);
            unitOfWork.Save();

            return "Success";
        }

    }
}