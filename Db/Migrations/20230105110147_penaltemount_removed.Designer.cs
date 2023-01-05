﻿// <auto-generated />
using System;
using Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Db.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20230105110147_penaltemount_removed")]
    partial class penaltemount_removed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Objects.Entities.Books", b =>
                {
                    b.Property<string>("ISDN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ISDN");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            ISDN = "0000",
                            AuthorName = "Dan Brown",
                            IsBooked = false,
                            Title = "Da Vinci Code"
                        },
                        new
                        {
                            ISDN = "1111",
                            AuthorName = "G.R.R Martin",
                            IsBooked = false,
                            Title = "Game of Thrones"
                        },
                        new
                        {
                            ISDN = "2222",
                            AuthorName = "George Orwell",
                            IsBooked = false,
                            Title = "1984"
                        },
                        new
                        {
                            ISDN = "3333",
                            AuthorName = "Edith Wharton",
                            IsBooked = false,
                            Title = "The House of Mirth"
                        },
                        new
                        {
                            ISDN = "4444",
                            AuthorName = "Ernest Hemingway",
                            IsBooked = false,
                            Title = "The Sun Also Rises"
                        },
                        new
                        {
                            ISDN = "5555",
                            AuthorName = "Lois Lowry",
                            IsBooked = false,
                            Title = "Number the Stars"
                        },
                        new
                        {
                            ISDN = "6666",
                            AuthorName = "Aldous Huxley",
                            IsBooked = false,
                            Title = "Brave New World"
                        },
                        new
                        {
                            ISDN = "7777",
                            AuthorName = "Vladimir Nabokov",
                            IsBooked = false,
                            Title = "Pale Fire"
                        },
                        new
                        {
                            ISDN = "8888",
                            AuthorName = "Stella Gibbons",
                            IsBooked = false,
                            Title = "Cold Comfort Farm"
                        },
                        new
                        {
                            ISDN = "99999",
                            AuthorName = "Margaret Mitchell",
                            IsBooked = false,
                            Title = "Gone With the Wind "
                        });
                });

            modelBuilder.Entity("Objects.Entities.BookTransactions", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BooksISDN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MembersMemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.HasIndex("BooksISDN");

                    b.HasIndex("MembersMemberId");

                    b.ToTable("BookTransactions");
                });

            modelBuilder.Entity("Objects.Entities.Holidays", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Date");

                    b.ToTable("Holidays");

                    b.HasData(
                        new
                        {
                            Date = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Date = new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Objects.Entities.Members", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1001160879,
                            Name = "London Crona"
                        },
                        new
                        {
                            MemberId = 778270072,
                            Name = "Lilian Kemmer"
                        },
                        new
                        {
                            MemberId = 102165447,
                            Name = "John Schuster"
                        });
                });

            modelBuilder.Entity("Objects.Entities.BookTransactions", b =>
                {
                    b.HasOne("Objects.Entities.Books", null)
                        .WithMany("_BookTransactions")
                        .HasForeignKey("BooksISDN");

                    b.HasOne("Objects.Entities.Members", null)
                        .WithMany("_BookTransactions")
                        .HasForeignKey("MembersMemberId");
                });

            modelBuilder.Entity("Objects.Entities.Books", b =>
                {
                    b.Navigation("_BookTransactions");
                });

            modelBuilder.Entity("Objects.Entities.Members", b =>
                {
                    b.Navigation("_BookTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
