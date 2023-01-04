using Db.Interfaces;
using Objects.Entities;

namespace Business
{
    public class BookService:IBookService
    {
        private IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Books> GetAllBooks()
        {
            return  unitOfWork.BookRepository.GetAllAsync().Result;
        }
    }
}