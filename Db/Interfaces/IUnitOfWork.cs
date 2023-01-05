using Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Books> BookRepository { get; }
        GenericRepository<Members> MemberRepository { get; }
        GenericRepository<BookTransactions> BookTransactionsRepository { get; }
        GenericRepository<Holidays> HolidaysRepository { get; }
    }
}
