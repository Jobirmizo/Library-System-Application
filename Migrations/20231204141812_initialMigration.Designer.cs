﻿// <auto-generated />
using System;
using Library_System_Application.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library_System_Application.Migrations
{
    [DbContext(typeof(LibrarySystemContext))]
    [Migration("20231204141812_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Library_System_Application.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("last_name");

                    b.HasKey("Id")
                        .HasName("PK__author__3214EC27EA465A5E");

                    b.ToTable("author", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryID");

                    b.Property<int>("CopiesOwned")
                        .HasColumnType("int")
                        .HasColumnName("copies_owned");

                    b.Property<int?>("Count")
                        .HasColumnType("int")
                        .HasColumnName("count");

                    b.Property<byte[]>("Image")
                        .HasColumnType("image")
                        .HasColumnName("image");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("language");

                    b.Property<string>("PublicationYear")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("publication_year");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("PK__books__3214EC273F96C019");

                    b.HasIndex("CategoryId");

                    b.ToTable("books", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.BookAuthor", b =>
                {
                    b.Property<int>("Auithotr")
                        .HasColumnType("int")
                        .HasColumnName("auithotr");

                    b.Property<int>("BooksId")
                        .HasColumnType("int")
                        .HasColumnName("booksID");

                    b.HasIndex("Auithotr");

                    b.HasIndex("BooksId");

                    b.ToTable("book_author", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PK__category__3214EC2749D075E5");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("bookID");

                    b.Property<DateTime?>("BorrowDate")
                        .HasColumnType("date")
                        .HasColumnName("borrow_date");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("date")
                        .HasColumnName("return_date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentID");

                    b.HasKey("Id")
                        .HasName("PK__loan__3214EC27B63496D0");

                    b.HasIndex("BookId");

                    b.HasIndex("StudentId");

                    b.ToTable("loan", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Okey")
                        .HasColumnType("int")
                        .HasColumnName("okey");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("char(5)")
                        .HasColumnName("password")
                        .IsFixedLength();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("char(7)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.HasKey("Id")
                        .HasName("PK__manager__3214EC27DD4F7513");

                    b.ToTable("manager", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BooksId")
                        .HasColumnType("int")
                        .HasColumnName("booksID");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentID");

                    b.HasKey("Id")
                        .HasName("PK__reservat__3214EC2721CC7E84");

                    b.HasIndex("BooksId");

                    b.HasIndex("StudentId");

                    b.ToTable("reservation", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("first_name");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false)
                        .HasColumnType("char(7)")
                        .HasColumnName("id_card")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("last_name");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasMaxLength(9)
                        .IsUnicode(false)
                        .HasColumnType("char(9)")
                        .HasColumnName("passport")
                        .IsFixedLength();

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .IsUnicode(false)
                        .HasColumnType("char(13)")
                        .HasColumnName("phone")
                        .IsFixedLength();

                    b.Property<string>("Role")
                        .HasMaxLength(55)
                        .IsUnicode(false)
                        .HasColumnType("varchar(55)")
                        .HasColumnName("role");

                    b.HasKey("Id")
                        .HasName("PK__student__3214EC272B6D402A");

                    b.ToTable("student", (string)null);
                });

            modelBuilder.Entity("Library_System_Application.Model.Book", b =>
                {
                    b.HasOne("Library_System_Application.Model.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__books__categoryI__5BE2A6F2");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Library_System_Application.Model.BookAuthor", b =>
                {
                    b.HasOne("Library_System_Application.Model.Author", "AuithotrNavigation")
                        .WithMany()
                        .HasForeignKey("Auithotr")
                        .IsRequired()
                        .HasConstraintName("FK__book_auth__auith__619B8048");

                    b.HasOne("Library_System_Application.Model.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .IsRequired()
                        .HasConstraintName("FK__book_auth__books__60A75C0F");

                    b.Navigation("AuithotrNavigation");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library_System_Application.Model.Loan", b =>
                {
                    b.HasOne("Library_System_Application.Model.Student", "Book")
                        .WithMany("LoanBooks")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__loan__bookID__72C60C4A");

                    b.HasOne("Library_System_Application.Model.Student", "Student")
                        .WithMany("LoanStudents")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__loan__studentID__71D1E811");

                    b.Navigation("Book");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Library_System_Application.Model.Reservation", b =>
                {
                    b.HasOne("Library_System_Application.Model.Book", "Books")
                        .WithMany("Reservations")
                        .HasForeignKey("BooksId")
                        .IsRequired()
                        .HasConstraintName("FK__reservati__books__6E01572D");

                    b.HasOne("Library_System_Application.Model.Student", "Student")
                        .WithMany("Reservations")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK__reservati__stude__6EF57B66");

                    b.Navigation("Books");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Library_System_Application.Model.Book", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Library_System_Application.Model.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library_System_Application.Model.Student", b =>
                {
                    b.Navigation("LoanBooks");

                    b.Navigation("LoanStudents");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
