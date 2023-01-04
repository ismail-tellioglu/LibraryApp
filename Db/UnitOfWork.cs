using Db.Interfaces;
using Microsoft.EntityFrameworkCore;
using Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class UnitOfWork : IDisposable,IUnitOfWork
    {
        private LibraryContext context;
        private GenericRepository<Books> bookRepository;
        private GenericRepository<Members> memberRepository;
        private GenericRepository<BookTransactions> bookTransactionsRepository;

        public UnitOfWork(LibraryContext libraryContext)
        {
            context = libraryContext;
        }

        public GenericRepository<Books> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Books>(context);
                }
                return bookRepository;
            }
        }

        public GenericRepository<Members> MemberRepository
        {
            get
            {

                if (this.memberRepository == null)
                {
                    this.memberRepository = new GenericRepository<Members>(context);
                }
                return memberRepository;
            }
        }
        public GenericRepository<BookTransactions> BookTransactionsRepository
        {
            get
            {

                if (this.bookTransactionsRepository == null)
                {
                    this.bookTransactionsRepository = new GenericRepository<BookTransactions>(context);
                }
                return bookTransactionsRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
