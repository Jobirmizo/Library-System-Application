using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library_System_Application.Model;

public partial class LibrarySystemContext : DbContext
{
    public LibrarySystemContext()
    {
    }

    public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookAuthor> BookAuthors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TRAVIS\\SQLEXPRESS;Database=LibrarySystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__author__3214EC27EA465A5E");

            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__books__3214EC273F96C019");

            entity.ToTable("books");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CopiesOwned).HasColumnName("copies_owned");
            entity.Property(e => e.Language)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("language");
            entity.Property(e => e.PublicationYear)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("publication_year");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__books__categoryI__5BE2A6F2");
        });

        modelBuilder.Entity<BookAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("book_author");

            entity.Property(e => e.Auithotr).HasColumnName("auithotr");
            entity.Property(e => e.BooksId).HasColumnName("booksID");

            entity.HasOne(d => d.AuithotrNavigation).WithMany()
                .HasForeignKey(d => d.Auithotr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__book_auth__auith__619B8048");

            entity.HasOne(d => d.Books).WithMany()
                .HasForeignKey(d => d.BooksId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__book_auth__books__60A75C0F");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3214EC2749D075E5");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loan__3214EC27B63496D0");

            entity.ToTable("loan");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BookId).HasColumnName("bookID");
            entity.Property(e => e.BorrowDate)
                .HasColumnType("date")
                .HasColumnName("borrow_date");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("date")
                .HasColumnName("return_date");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Book).WithMany(p => p.LoanBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__loan__bookID__72C60C4A");

            entity.HasOne(d => d.Student).WithMany(p => p.LoanStudents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__loan__studentID__71D1E811");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__manager__3214EC27DD4F7513");

            entity.ToTable("manager");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Okey).HasColumnName("okey");
            entity.Property(e => e.Password)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("username");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__reservat__3214EC2721CC7E84");

            entity.ToTable("reservation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BooksId).HasColumnName("booksID");
            entity.Property(e => e.StudentId).HasColumnName("studentID");

            entity.HasOne(d => d.Books).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.BooksId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservati__books__6E01572D");

            entity.HasOne(d => d.Student).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__reservati__stude__6EF57B66");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__student__3214EC272B6D402A");

            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.IdCard)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_card");
            entity.Property(e => e.LastName)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.Passport)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("passport");
            entity.Property(e => e.Phone)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
