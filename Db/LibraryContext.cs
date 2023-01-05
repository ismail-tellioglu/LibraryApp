using Microsoft.EntityFrameworkCore;
using Objects.Entities;
using System.Reflection.Emit;

namespace Db
{
    public class LibraryContext:DbContext
    {
        public LibraryContext() { }
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            InitialData.Init(3);

            modelBuilder.Entity<Books>().HasData(InitialData.books);
            modelBuilder.Entity<Members>().HasData(InitialData.members);
            modelBuilder.Entity<Holidays>().HasData(InitialData.holidays);
        }

        DbSet<Books> Books { get; set; }
        DbSet<BookTransactions> BookTransactions { get; set; }
        DbSet<Members> Members { get; set; }
        DbSet<Holidays> Holidays { get; set; }
    }
}